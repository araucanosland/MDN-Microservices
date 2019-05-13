using System;
using System.Data;
using System.Data.SqlClient;

namespace CDK.Data
{
    /// <summary>
    /// Transaccion
    /// </summary>
    public class Transaccion : ITransaccion
    {
        /// <summary>
        /// Referencia a la Conexión
        /// </summary>
        internal SqlConnection connection;

        /// <summary>
        /// Referencia a la Transacción
        /// </summary>
        internal SqlTransaction transaction;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaccion" /> class.
        /// </summary>
        internal Transaccion(SqlConnection sqlConnection, eIsolationLevel isolationLevel)
        {
            connection = sqlConnection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            transaction = connection.BeginTransaction((IsolationLevel) isolationLevel);
            
            _previous = _activa;
            _activa = this;
            EstaCompletado = false;
        }

        [ThreadStatic]
        private static Transaccion _activa;

        private readonly Transaccion _previous;

        /// <summary>
        /// Activa
        /// </summary>
        public static Transaccion Activa
        {
            get
            {
                return _activa;
            }
        }

        /// <summary>
        /// EstaCompletado
        /// </summary>
        public bool EstaCompletado { get; set; }

        /// <summary>
        /// Cancela la Transacción
        /// </summary>
        public void Cancelar()
        {
            transaction.Rollback();

            Cerrar();
        }

        /// <summary>
        /// Completa la Transacción
        /// </summary>
        public void Completar()
        {
            transaction.Commit();

            Cerrar();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!EstaCompletado)
            {
                Cancelar();
            }
            _activa = _previous;
        }

        private void Cerrar()
        {
            transaction = null;
            EstaCompletado = true;

            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
            connection = null;
        }
    }
}
