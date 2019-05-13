using System;
using System.Collections.Generic;
using System.Data;

namespace CDK.Data
{
    /// <summary>
    /// Interfaz Base para Clases de Base de Datos
    /// </summary>
    public interface IDBHelper
    {
        /// <summary>
        /// Cadena de conexión
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// Cadena de conexión
        /// </summary>
        string ConnectionStringKey { get; }

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
        T ObtenerEntidad<T>(string procedimiento, Parametros parametros, Func<DataRow, T> constructor) where T : new();

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
        T ObtenerEntidad<T>(string procedimiento, Parametros parametros, Func<IDataReader, T> constructor) where T : new();

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
        T ObtenerEntidad<T>(string procedimiento, Parametro parametro, Func<DataRow, T> constructor) where T : new();

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
        T ObtenerEntidad<T>(string procedimiento, Parametro parametro, Func<IDataReader, T> constructor) where T : new();

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        T ObtenerEntidad<T>(string procedimiento, Func<DataRow, T> constructor) where T : new();

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        T ObtenerEntidad<T>(string procedimiento, Func<IDataReader, T> constructor) where T : new();

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
        T ObtenerEntidadFromSql<T>(string query, Parametros parametros, Func<DataRow, T> constructor) where T : new();

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
        T ObtenerEntidadFromSql<T>(string query, Parametros parametros, Func<IDataReader, T> constructor) where T : new();

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
        T ObtenerEntidadFromSql<T>(string query, Parametro parametro, Func<DataRow, T> constructor) where T : new();

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
        T ObtenerEntidadFromSql<T>(string query, Parametro parametro, Func<IDataReader, T> constructor) where T : new();

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        T ObtenerEntidadFromSql<T>(string query, Func<DataRow, T> constructor) where T : new();

        /// <summary>
        /// Recupera una Entidad de la Base de Datos a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="constructor">Delegado para construir la entidad a partir del resultado</param>
        /// <returns>
        /// Entidad de la base de datos
        /// </returns>
        /// 
        T ObtenerEntidadFromSql<T>(string query, Func<IDataReader, T> constructor) where T : new();

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
        List<T> ObtenerColeccion<T>(string procedimiento, Parametros parametros, Func<DataRow, T> constructor) where T : new();

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
        List<T> ObtenerColeccion<T>(string procedimiento, Parametros parametros, Func<IDataReader, T> constructor) where T : new();

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
        List<T> ObtenerColeccion<T>(string procedimiento, Parametro parametro, Func<DataRow, T> constructor) where T : new();

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
        List<T> ObtenerColeccion<T>(string procedimiento, Parametro parametro, Func<IDataReader, T> constructor) where T : new();

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
        List<T> ObtenerColeccion<T>(string procedimiento, Func<DataRow, T> constructor) where T : new();

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
        List<T> ObtenerColeccion<T>(string procedimiento, Func<IDataReader, T> constructor) where T : new();

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
        List<T> ObtenerColeccionFromSql<T>(string query, Parametros parametros, Func<DataRow, T> constructor) where T : new();

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
        List<T> ObtenerColeccionFromSql<T>(string query, Parametros parametros, Func<IDataReader, T> constructor) where T : new();

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
        List<T> ObtenerColeccionFromSql<T>(string query, Parametro parametro, Func<DataRow, T> constructor) where T : new();

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
        List<T> ObtenerColeccionFromSql<T>(string query, Parametro parametro, Func<IDataReader, T> constructor) where T : new();

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
        List<T> ObtenerColeccionFromSql<T>(string query, Func<DataRow, T> constructor) where T : new();

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
        List<T> ObtenerColeccionFromSql<T>(string query, Func<IDataReader, T> constructor) where T : new();

        /// <summary>
        /// Recupera un <see cref="DataTable" /> a partir de un procedimiento almacenado
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros para invocar el procedimiento</param>
        /// <returns>
        /// Tabla con los registros extraidos
        /// </returns>
        DataTable ObtenerDataTable(string procedimiento, Parametros parametros = null);

        /// <summary>
        /// Recupera un <see cref="DataTable" /> a partir de un procedimiento almacenado
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parametro para invocar el procedimiento</param>
        /// <returns>
        /// Tabla con los registros extraidos
        /// </returns>
        DataTable ObtenerDataTable(string procedimiento, Parametro parametro);

        /// <summary>
        /// Recupera un <see cref="DataTable" /> a partir de una consulta estructurada
        /// </summary>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametros">Parametros para adjuntar a la consulta</param>
        /// <returns>
        /// Tabla con los registros extraidos
        /// </returns>
        DataTable ObtenerDataTableFromSql(string query, Parametros parametros = null);

        /// <summary>
        /// Recupera un <see cref="DataTable" /> a partir de una consulta estructurada
        /// </summary>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer los datos</param>
        /// <param name="parametro">Parametro para adjuntar a la consulta</param>
        /// <returns>
        /// Tabla con los registros extraidos
        /// </returns>
        DataTable ObtenerDataTableFromSql(string query, Parametro parametro);

        /// <summary>
        /// Recupera un valor estalar a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo de dato del escalar</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros para invocar el procedimiento</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        T ObtenerEscalar<T>(string procedimiento, Parametros parametros = null);

        /// <summary>
        /// Recupera un valor estalar a partir de un procedimiento almacenado
        /// </summary>
        /// <typeparam name="T">Tipo de dato del escalar</typeparam>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parametro para invocar el procedimiento</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        T ObtenerEscalar<T>(string procedimiento, Parametro parametro);

        /// <summary>
        /// Recupera un valor estalar a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo de dato del escalar</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer el escalar</param>
        /// <param name="parametros">Parametros para adjuntar a la consulta</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        T ObtenerEscalarFromSql<T>(string query, Parametros parametros = null);

        /// <summary>
        /// Recupera un valor estalar a partir de una consulta estructurada
        /// </summary>
        /// <typeparam name="T">Tipo de dato del escalar</typeparam>
        /// <param name="query">Consulta del tipo <c>SELECT</c> para extraer el escalar</param>
        /// <param name="parametro">Parametro para adjuntar a la consulta</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        T ObtenerEscalarFromSql<T>(string query, Parametro parametro);

        /// <summary>
        /// Ejecuta directamente un procedimiento almacenado
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros para invocar el procedimiento</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        int EjecutarProcedimiento(string procedimiento, Parametros parametros = null);

        /// <summary>
        /// Ejecuta directamente un procedimiento almacenado
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="parametro">Parametro para invocar el procedimiento</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        int EjecutarProcedimiento(string procedimiento, Parametro parametro);

        /// <summary>
        /// Ejecuta directamente una consulta estructurada
        /// </summary>
        /// <param name="query">Consulta estructurada de cualquier tipo</param>
        /// <param name="parametros">Parametros para adjuntar a la consulta</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        int EjecutarSql(string query, Parametros parametros = null);

        /// <summary>
        /// Ejecuta directamente una consulta estructurada
        /// </summary>
        /// <param name="query">Consulta estructurada de cualquier tipo</param>
        /// <param name="parametro">Parametro para adjuntar a la consulta</param>
        /// <returns>
        /// Valor escalar retornado de la base de datos
        /// </returns>
        int EjecutarSql(string query, Parametro parametro);
    }
}
