using System;
using System.Data;

namespace CDK.Data
{
    /// <summary>
    /// Clase Parametro
    /// </summary>
    public class Parametro
    {
        /// <summary>
        /// Tipo
        /// </summary>
        public eTipoParametro Tipo { get; private set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// Valor
        /// </summary>
        public object Valor { get; private set; }

        /// <summary>
        /// Nombre Tipo
        /// </summary>
        public string NombreTipo { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        /// <param name="tipo">Tipo de dato del parámetro</param>
        public Parametro(string nombre, object valor, eTipoParametro tipo = eTipoParametro.DEFAULT)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = tipo;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, bool valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.BOOL;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, float valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.FLOAT;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, double valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.DOUBLE;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, double? valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.DOUBLE;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, decimal valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.DECIMAL;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, decimal? valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.DECIMAL;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, long valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.LONG;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, long? valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.LONG;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, int valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.INT;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, int? valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.INT;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, short? valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.SHORT;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, short valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.SHORT;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro" />.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        /// <param name="esTexto">dejar en <c>true</c> para indicar que el tipo de dato es texto en vez de varchar</param>
        /// <param name="esTextoLargo">dejar en <c>true</c> para indicar que el tipo de datos es texto largo en vez de texto normal</param>
        public Parametro(string nombre, string valor, bool esTexto = false, bool esTextoLargo = false)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = esTexto ? esTextoLargo ? eTipoParametro.LONG_TEXT : eTipoParametro.TEXT : eTipoParametro.VARCHAR;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        /// <param name="esFechaSimple">dejar en<c>true</c> para indicar que el tipo de dato es fecha simple (sin horas y minutos)</param>
        public Parametro(string nombre, DateTime valor, bool esFechaSimple = false)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = esFechaSimple ? eTipoParametro.DATE : eTipoParametro.DATETIME;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro"/>.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        public Parametro(string nombre, Guid valor)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.GUID;
            NombreTipo = string.Empty;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Parametro" />.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro</param>
        /// <param name="valor">Valor del parámetro</param>
        /// <param name="nombreTipo">The nombre tipo.</param>
        public Parametro(string nombre, DataTable valor, string nombreTipo = "")
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = eTipoParametro.DATATABLE;
            NombreTipo = nombreTipo;
        }
    }
}
