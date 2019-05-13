using System;

namespace CDK.Data
{
    /// <summary>
    /// Interfaz Base para Clases de Transacciones
    /// </summary>
    public interface ITransaccion : IDisposable
    {
        /// <summary>
        /// EstaCompletado
        /// </summary>
        bool EstaCompletado { get; set; }

        /// <summary>
        /// Cancela la Transacción
        /// </summary>
        void Cancelar();

        /// <summary>
        /// Completa la Transacción
        /// </summary>
        void Completar();
    }
}
