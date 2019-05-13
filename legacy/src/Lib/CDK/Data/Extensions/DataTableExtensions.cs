using System.Collections.Generic;
using System.Data;

namespace CDK.Data.Extensions
{
    /// <summary>
    /// DataTableExtensions
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Merges the specified table1.
        /// </summary>
        /// <param name="table1">The table1.</param>
        /// <param name="table2">The table2.</param>
        /// <param name="columnaPrimaria">The columna primaria.</param>
        /// <returns></returns>
        public static DataTable Mezclar(this DataTable table1, DataTable table2, string columnaPrimaria = "")
        {
            return DataTableHelper.MezclarTablas(table1, table2, columnaPrimaria);
        }

        /// <summary>
        /// ToList
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columnaValor"></param>
        /// <returns></returns>
        public static List<object> ToList(this DataTable table, string columnaValor)
        {
            return DataTableHelper.ConvertToList(table, columnaValor);
        }
    }
}
