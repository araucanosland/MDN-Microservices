using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace CDK.Data
{
    /// <summary>
    /// Clase DBHelperBase
    /// </summary>
    public class DBHelperBase : IDBHelper
    {
        /// <summary>
        /// Cadena de conexión de esta instancia
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// Cadena de conexión de esta instancia
        /// </summary>
        /// 
        public string ConnectionStringKey { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DBHelperBase" /> class.
        /// </summary>
        /// <param name="connectionStringKey">Clave de cadena de conexión</param>
        /// <param name="isFullConnectionString">Dejar en <c>true</c> para indicar que el ConnectionString es el parámetro.</param>
        public DBHelperBase(string connectionStringKey, bool isFullConnectionString = false)
        {
            ConnectionStringKey = !isFullConnectionString ? connectionStringKey : string.Empty;
            ConnectionString = isFullConnectionString ? connectionStringKey : Configuration.GetConnectionString(connectionStringKey);
        }
        public static IConfigurationRoot Configuration { 
            get
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true);

                if(env != null){
                    builder.AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);
                }
                    
                return builder.Build();
            }
        }


        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros para invocar el procedimiento</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidad<T>(string procedimiento, Parametros parametros, Func<DataRow, T> constructor) where T : new()
        {
            DataTable table = new DataTable();

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Procedimiento Almacenado
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedimiento;

                    ConfigurarParametros(parametros, command);

                    SqlDataReader reader = command.ExecuteReader();
                    table.Load(reader);
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return table.Rows.Count > 0 ? constructor(table.Rows[0]) : new T();
        }

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros para invocar el procedimiento</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidad<T>(string procedimiento, Parametros parametros, Func<IDataReader, T> constructor) where T : new()
        {
            T item = new T();

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Procedimiento Almacenado
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedimiento;

                    ConfigurarParametros(parametros, command);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            item = constructor(reader);
                        }
                    }
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return item;
        }

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parametro para invocar el procedimiento</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidad<T>(string procedimiento, Parametro parametro, Func<DataRow, T> constructor) where T : new()
        {
            return ObtenerEntidad(procedimiento,
                                  new Parametros
                                      {
                                          parametro
                                      },
                                  constructor);
        }

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parametro para invocar el procedimiento</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidad<T>(string procedimiento, Parametro parametro, Func<IDataReader, T> constructor) where T : new()
        {
            return ObtenerEntidad(procedimiento,
                                  new Parametros
                                      {
                                          parametro
                                      },
                                  constructor);
        }

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidad<T>(string procedimiento, Func<DataRow, T> constructor) where T : new()
        {
            return ObtenerEntidad(procedimiento, new Parametros(), constructor);
        }

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidad<T>(string procedimiento, Func<IDataReader, T> constructor) where T : new()
        {
            return ObtenerEntidad(procedimiento, new Parametros(), constructor);
        }

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametros">Parametros para adjuntar a la consulta</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidadFromSql<T>(string query, Parametros parametros, Func<DataRow, T> constructor) where T : new()
        {
            DataTable table = new DataTable();

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Texto
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;

                    ConfigurarParametros(parametros, command);

                    SqlDataReader reader = command.ExecuteReader();
                    table.Load(reader);
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return table.Rows.Count > 0 ? constructor(table.Rows[0]) : new T();
        }

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametros">Parametros para adjuntar a la consulta</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidadFromSql<T>(string query, Parametros parametros, Func<IDataReader, T> constructor) where T : new()
        {
            T item = new T();

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Texto
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;

                    ConfigurarParametros(parametros, command);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            item = constructor(reader);
                        }
                    }
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return item;
        }

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametro">Parametro para adjuntar a la consulta</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidadFromSql<T>(string query, Parametro parametro, Func<DataRow, T> constructor) where T : new()
        {
            return ObtenerEntidadFromSql(query,
                                         new Parametros
                                             {
                                                 parametro
                                             },
                                         constructor);
        }

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametro">Parametro para adjuntar a la consulta</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidadFromSql<T>(string query, Parametro parametro, Func<IDataReader, T> constructor) where T : new()
        {
            return ObtenerEntidadFromSql(query,
                                         new Parametros
                                             {
                                                 parametro
                                             },
                                         constructor);
        }

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidadFromSql<T>(string query, Func<DataRow, T> constructor) where T : new()
        {
            return ObtenerEntidadFromSql(query, new Parametros(), constructor);
        }

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        public T ObtenerEntidadFromSql<T>(string query, Func<IDataReader, T> constructor) where T : new()
        {
            return ObtenerEntidadFromSql(query, new Parametros(), constructor);
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros para invocar el procedimiento</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see>
        /// <cref>ObtenerDataTable</cref>
        /// </see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccion<T>(string procedimiento, Parametros parametros, Func<DataRow, T> constructor) where T : new()
        {
            DataTable table = new DataTable();

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Procedimiento Almacenado
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedimiento;

                    ConfigurarParametros(parametros, command);

                    SqlDataReader reader = command.ExecuteReader();
                    table.Load(reader);
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return (from DataRow row in table.Rows select constructor(row)).ToList();
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros para invocar el procedimiento</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see><cref>ObtenerDataTable</cref></see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccion<T>(string procedimiento, Parametros parametros, Func<IDataReader, T> constructor) where T : new()
        {
            List<T> lista = new List<T>();

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Procedimiento Almacenado
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedimiento;

                    ConfigurarParametros(parametros, command);

                    using (IDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            T item = constructor(dr);
                            lista.Add(item);
                        }
                    }
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return lista;
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parametro para invocar el procedimiento</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see>
        /// <cref>ObtenerDataTable</cref>
        /// </see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccion<T>(string procedimiento, Parametro parametro, Func<DataRow, T> constructor) where T : new()
        {
            return ObtenerColeccion(procedimiento,
                                    new Parametros
                                        {
                                            parametro
                                        },
                                    constructor);
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parametro para invocar el procedimiento</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see><cref>ObtenerDataTable</cref></see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccion<T>(string procedimiento, Parametro parametro, Func<IDataReader, T> constructor) where T : new()
        {
            return ObtenerColeccion(procedimiento,
                                    new Parametros
                                        {
                                            parametro
                                        },
                                    constructor);
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see>
        /// <cref>ObtenerDataTable</cref>
        /// </see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccion<T>(string procedimiento, Func<DataRow, T> constructor) where T : new()
        {
            return ObtenerColeccion(procedimiento, new Parametros(), constructor);
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see><cref>ObtenerDataTable</cref></see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccion<T>(string procedimiento, Func<IDataReader, T> constructor) where T : new()
        {
            return ObtenerColeccion(procedimiento, new Parametros(), constructor);
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametros">Parametros para adjuntar a la consulta</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see>
        /// <cref>ObtenerDataTableFromSql</cref>
        /// </see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccionFromSql<T>(string query, Parametros parametros, Func<DataRow, T> constructor) where T : new()
        {
            DataTable table = new DataTable();

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Texto
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;

                    ConfigurarParametros(parametros, command);

                    SqlDataReader reader = command.ExecuteReader();
                    table.Load(reader);
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return (from DataRow row in table.Rows select constructor(row)).ToList();
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametros">Parametros para adjuntar a la consulta</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see><cref>ObtenerDataTableFromSql</cref></see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccionFromSql<T>(string query, Parametros parametros, Func<IDataReader, T> constructor) where T : new()
        {
            List<T> lista = new List<T>();

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Texto
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;

                    ConfigurarParametros(parametros, command);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T item = constructor(reader);
                            lista.Add(item);
                        }
                    }
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return lista;
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametro">Parametro para adjuntar a la consulta</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see>
        /// <cref>ObtenerDataTableFromSql</cref>
        /// </see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccionFromSql<T>(string query, Parametro parametro, Func<DataRow, T> constructor) where T : new()
        {
            return ObtenerColeccionFromSql(query,
                                           new Parametros
                                               {
                                                   parametro
                                               },
                                           constructor);
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametro">Parametro para adjuntar a la consulta</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see><cref>ObtenerDataTableFromSql</cref></see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccionFromSql<T>(string query, Parametro parametro, Func<IDataReader, T> constructor) where T : new()
        {
            return ObtenerColeccionFromSql(query,
                                           new Parametros
                                               {
                                                   parametro
                                               },
                                           constructor);
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see>
        /// <cref>ObtenerDataTableFromSql</cref>
        /// </see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccionFromSql<T>(string query, Func<DataRow, T> constructor) where T : new()
        {
            return ObtenerColeccionFromSql(query, new Parametros(), constructor);
        }

        /// <summary>
        /// Recupera una colección de entidades de la base de datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Lista con las entidades de la base de datos
        /// </returns>
        /// <remarks>
        /// Esta función es costosa, no utilizar con una gran colección de datos, utilizar mejor <see><cref>ObtenerDataTableFromSql</cref></see>
        /// para manejar un mayor volúmen de datos
        /// </remarks>
        public List<T> ObtenerColeccionFromSql<T>(string query, Func<IDataReader, T> constructor) where T : new()
        {
            return ObtenerColeccionFromSql(query, new Parametros(), constructor);
        }

        /// <summary>
        /// Recupera un <see cref="DataTable" /> a partir de un procedimiento almacenado
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros para invocar el procedimiento</param>
        /// <returns>
        /// Tabla con los registros extraidos
        /// </returns>
        public DataTable ObtenerDataTable(string procedimiento, Parametros parametros = null)
        {
            DataTable table = new DataTable("Results");

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Procedimiento Almacenado
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedimiento;

                    ConfigurarParametros(parametros, command);

                    SqlDataReader reader = command.ExecuteReader();
                    table.Load(reader);
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return table;
        }

        /// <summary>
        /// Recupera un <see cref="DataTable" /> a partir de un procedimiento almacenado
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parametro para invocar el procedimiento</param>
        /// <returns>
        /// Tabla con los registros extraidos
        /// </returns>
        public DataTable ObtenerDataTable(string procedimiento, Parametro parametro)
        {
            return ObtenerDataTable(procedimiento,
                                    new Parametros
                                        {
                                            parametro
                                        });
        }

        /// <summary>
        /// Recupera un <see cref="DataTable" /> a partir de una consulta estructurada
        /// </summary>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametros">Parametros para adjuntar a la consulta</param>
        /// <returns>
        /// Tabla con los registros extraidos
        /// </returns>
        public DataTable ObtenerDataTableFromSql(string query, Parametros parametros = null)
        {
            DataTable table = new DataTable("Results");

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Texto
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;

                    ConfigurarParametros(parametros, command);

                    SqlDataReader reader = command.ExecuteReader();
                    table.Load(reader);
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return table;
        }

        /// <summary>
        /// Recupera un <see cref="DataTable" /> a partir de una consulta estructurada
        /// </summary>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametro">Parametro para adjuntar a la consulta</param>
        /// <returns>
        /// Tabla con los registros extraidos
        /// </returns>
        public DataTable ObtenerDataTableFromSql(string query, Parametro parametro)
        {
            return ObtenerDataTableFromSql(query,
                                           new Parametros
                                               {
                                                   parametro
                                               });
        }

        /// <summary>
        /// Recupera un valor estalar a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo de dato del escalar</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros para invocar el procedimiento</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        public T ObtenerEscalar<T>(string procedimiento, Parametros parametros = null)
        {
            object result;

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Procedimiento Almacenado
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedimiento;

                    ConfigurarParametros(parametros, command);

                    result = command.ExecuteScalar() ?? default(T);
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return (T) Convert.ChangeType(result, typeof (T));
        }

        /// <summary>
        /// Recupera un valor estalar a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo de dato del escalar</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parametro para invocar el procedimiento</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        public T ObtenerEscalar<T>(string procedimiento, Parametro parametro)
        {
            return ObtenerEscalar<T>(procedimiento,
                                     new Parametros
                                         {
                                             parametro
                                         });
        }

        /// <summary>
        /// Recupera un valor estalar a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo de dato del escalar</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer el escalar</param>
        /// <param name="parametros">Parametros para adjuntar a la consulta</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        public T ObtenerEscalarFromSql<T>(string query, Parametros parametros = null)
        {
            object result;

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Texto
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;

                    ConfigurarParametros(parametros, command);

                    result = command.ExecuteScalar() ?? default(T);
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return (T) Convert.ChangeType(result, typeof (T));
        }

        /// <summary>
        /// Recupera un valor estalar a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo de dato del escalar</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer el escalar</param>
        /// <param name="parametro">Parametro para adjuntar a la consulta</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        public T ObtenerEscalarFromSql<T>(string query, Parametro parametro)
        {
            return ObtenerEscalarFromSql<T>(query,
                                            new Parametros
                                                {
                                                    parametro
                                                });
        }

        /// <summary>
        /// Ejecuta directamente un procedimiento almacenado
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros para invocar el procedimiento</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        public int EjecutarProcedimiento(string procedimiento, Parametros parametros = null)
        {
            int result;

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Procedimiento Almacenado
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedimiento;

                    ConfigurarParametros(parametros, command);

                    result = command.ExecuteNonQuery();
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return result;
        }

        /// <summary>
        /// Ejecuta directamente un procedimiento almacenado
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parametro para invocar el procedimiento</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        public int EjecutarProcedimiento(string procedimiento, Parametro parametro)
        {
            return EjecutarProcedimiento(procedimiento,
                                         new Parametros
                                             {
                                                 parametro
                                             });
        }

        /// <summary>
        /// Ejecuta directamente una consulta estructurada
        /// </summary>
        /// <param name="query">Consulta estructurada de cualquier tipo</param>
        /// <param name="parametros">Parametros para adjuntar a la consulta</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        public int EjecutarSql(string query, Parametros parametros = null)
        {
            int result;

            // Preparo la conexión a Sqlite
            SqlConnection connection = ObtenerConexionActiva();

            try
            {
                AbrirConexion(connection);

                // Creo el comando de consulta de tipo Texto
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;

                    ConfigurarParametros(parametros, command);

                    result = command.ExecuteNonQuery();
                }
            }
            finally
            {
                CerrarConexion(connection);
            }

            return result;
        }

        /// <summary>
        /// Ejecuta directamente una consulta estructurada
        /// </summary>
        /// <param name="query">Consulta estructurada de cualquier tipo</param>
        /// <param name="parametro">Parametro para adjuntar a la consulta</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        public int EjecutarSql(string query, Parametro parametro)
        {
            return EjecutarSql(query,
                               new Parametros
                                   {
                                       parametro
                                   });
        }

        /// <summary>
        /// Crea una nueva transacción para la conexión activa
        /// </summary>
        /// <returns>Referencia a una nueva <see cref="Transaccion"/></returns>
        public Transaccion CrearTransaccion(eIsolationLevel isolationLevel = eIsolationLevel.READ_COMMITTED)
        {
            return new Transaccion(new SqlConnection(ConnectionString), isolationLevel);
        }

        private SqlConnection ObtenerConexionActiva()
        {
            Transaccion context = Transaccion.Activa;

            return context != null ? context.connection : new SqlConnection(ConnectionString);
        }

        private void ConfigurarParametros(IEnumerable<Parametro> parametros, SqlCommand command)
        {
            Transaccion context = Transaccion.Activa;
            if (context != null)
            {
                command.Transaction = context.transaction;
            }

            if (parametros != null)
            {
                foreach (Parametro parametro in parametros)
                {
                    command.Parameters.Add(ObtenerParametro(parametro));
                }
            }
        }

        private SqlParameter ObtenerParametro(Parametro parametro)
        {
            switch (parametro.Tipo)
            {
                default:{ return new SqlParameter(parametro.Nombre, parametro.Valor); }
                case eTipoParametro.BINARY: { return new SqlParameter(parametro.Nombre, SqlDbType.Binary) { Value = parametro.Valor }; }
                case eTipoParametro.BOOL: { return new SqlParameter(parametro.Nombre, SqlDbType.Bit) { Value = parametro.Valor }; }
                case eTipoParametro.FLOAT: { return new SqlParameter(parametro.Nombre, SqlDbType.Float) { Value = parametro.Valor }; }
                case eTipoParametro.DOUBLE: { return new SqlParameter(parametro.Nombre, SqlDbType.Real) { Value = parametro.Valor }; }
                case eTipoParametro.DECIMAL: { return new SqlParameter(parametro.Nombre, SqlDbType.Decimal) { Value = parametro.Valor }; }
                case eTipoParametro.LONG: { return new SqlParameter(parametro.Nombre, SqlDbType.BigInt) { Value = parametro.Valor }; }
                case eTipoParametro.INT: { return new SqlParameter(parametro.Nombre, SqlDbType.Int) { Value = parametro.Valor }; }
                case eTipoParametro.SHORT: { return new SqlParameter(parametro.Nombre, SqlDbType.SmallInt) { Value = parametro.Valor }; }
                case eTipoParametro.VARCHAR: { return new SqlParameter(parametro.Nombre, SqlDbType.VarChar) { Value = parametro.Valor }; }
                case eTipoParametro.TEXT: { return new SqlParameter(parametro.Nombre, SqlDbType.Text) { Value = parametro.Valor }; }
                case eTipoParametro.LONG_TEXT: { return new SqlParameter(parametro.Nombre, SqlDbType.Text) { Value = parametro.Valor }; }
                case eTipoParametro.DATETIME: { return new SqlParameter(parametro.Nombre, SqlDbType.DateTime) { Value = parametro.Valor }; }
                case eTipoParametro.DATE: { return new SqlParameter(parametro.Nombre, SqlDbType.Date) { Value = parametro.Valor }; }
                case eTipoParametro.GUID: { return new SqlParameter(parametro.Nombre, SqlDbType.UniqueIdentifier) { Value = parametro.Valor }; }
                case eTipoParametro.DATATABLE:
                    {
                        return !string.IsNullOrWhiteSpace(parametro.NombreTipo)
                                   ? new SqlParameter(parametro.Nombre, SqlDbType.Udt)
                                       {
                                           TypeName = parametro.NombreTipo,
                                           Value = parametro.Valor
                                       }
                                   : new SqlParameter(parametro.Nombre, parametro.Valor);
                    }
            }
        }

        internal void AbrirConexion(SqlConnection connection)
        {
            if (Transaccion.Activa == null && connection != null && connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        internal void CerrarConexion(SqlConnection connection)
        {
            if (Transaccion.Activa == null && connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
