using System.Data;

namespace CDK.Data
{
    /// <summary>
    /// Enumeración de Tipo de Aislamiento
    /// </summary>
    public enum eIsolationLevel
    {
        /// <summary>
        /// Se utiliza un nivel de aislamiento distinto al especificado, pero no se puede
        /// determinar el nivel.
        /// </summary>
        /// <remarks>
        /// Al utilizar OdbcTransaction, si no establece IsolationLevel o establece
        /// IsolationLevel en Unspecified,  la transacción se ejecuta según el nivel de
        /// aislamiento predeterminado que determina el controlador que se utiliza.
        /// </remarks>
        UNSPECIFIED = IsolationLevel.Unspecified,

        /// <summary>
        /// Los cambios pendientes de las transacciones más aisladas no se pueden
        /// sobrescribir.
        /// </summary>
        CHAOS = IsolationLevel.Chaos,

        /// <summary>
        /// Se pueden producir lecturas erróneas, lo que implica que no se emitan bloqueos
        /// compartidos y que no se cumplan los bloqueos exclusivos.
        /// </summary>
        READ_UNCOMMITTED = IsolationLevel.ReadUncommitted,

        /// <summary>
        /// Los bloqueos compartidos se mantienen mientras se están leyendo los datos para
        /// evitar lecturas erróneas. Sin embargo, es posible cambiar los datos antes del
        /// fin de la transacción, lo que provoca lecturas no repetibles o datos fantasma.
        /// </summary>
        READ_COMMITTED = IsolationLevel.ReadCommitted,

        /// <summary>
        /// Los bloqueos se realizan sobre todos los datos utilizados en una consulta para
        /// evitar que otros usuarios actualicen dichos datos. Esto evita las lecturas no
        /// repetibles pero sigue existiendo la posibilidad de que se produzcan filas
        /// fantasma.
        /// </summary>
        REPEATABLE_READ = IsolationLevel.RepeatableRead,

        /// <summary>
        /// Se realiza un bloqueo de intervalo en <see cref="DataSet"/>, lo que impide que
        /// otros usuarios actualicen o inserten filas en el conjunto de datos hasta que la
        /// transacción haya terminado.
        /// </summary>
        SERIALIZABLE = IsolationLevel.Serializable,

        /// <summary>
        /// Reduce el bloqueo almacenando una versión de los datos que una aplicación puede
        /// leer mientras otra los está modificando. Indica que de una transacción no se
        /// pueden ver los cambios realizados en otras transacciones, aunque se vuelva a
        /// realizar una consulta.
        /// </summary>
        SNAPSHOT = IsolationLevel.Snapshot
    }
}
