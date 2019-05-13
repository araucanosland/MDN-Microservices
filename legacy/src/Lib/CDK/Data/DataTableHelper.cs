using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace CDK.Data
{
    /// <summary>
    /// DataTableHelper
    /// </summary>
    public static class DataTableHelper
    {
        /// <summary>
        /// MezclarTablas
        /// </summary>
        /// <returns></returns>
        public static DataTable MezclarTablas(DataTable dataTable1, DataTable dataTable2, string columnaPrimaria = "")
        {
            if (!string.IsNullOrWhiteSpace(columnaPrimaria))
            {
                if (!dataTable1.Columns.Contains(columnaPrimaria))
                {
                    throw new InvalidDataException("El primer DataTable no contiene una columna con el nombre " + columnaPrimaria);
                }

                if (!dataTable2.Columns.Contains(columnaPrimaria))
                {
                    throw new InvalidDataException("El segundo DataTable no contiene una columna con el nombre " + columnaPrimaria);
                }
            }

            DataTable table = new DataTable(string.Format("{0}_{1}", dataTable1.TableName, dataTable2.TableName));

            // Agregó las columnas del Primer DataTable
            foreach (DataColumn column in dataTable1.Columns.Cast<DataColumn>().Where(column => !table.Columns.Contains(column.ColumnName)))
            {
                table.Columns.Add(column.ColumnName, column.DataType);
            }

            // Agregó las columnas del Primer DataTable
            foreach (DataColumn column in dataTable2.Columns.Cast<DataColumn>().Where(column => !table.Columns.Contains(column.ColumnName)))
            {
                table.Columns.Add(column.ColumnName, column.DataType);
            }

            if (string.IsNullOrWhiteSpace(columnaPrimaria))
            {
                // Ingreso todas las filas del primer DataTable
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    DataRow newRow = table.NewRow();

                    // Recorro las columnas del DataTable
                    foreach (DataColumn column in dataTable1.Columns)
                    {
                        newRow[column.ColumnName] = row1[column.ColumnName];
                    }

                    table.Rows.Add(newRow);
                }

                // Ingreso todas las filas del segundo DataTable
                foreach (DataRow row2 in dataTable2.Rows)
                {
                    DataRow newRow = table.NewRow();

                    foreach (DataColumn column in dataTable2.Columns)
                    {
                        newRow[column.ColumnName] = row2[column.ColumnName];
                    }

                    table.Rows.Add(newRow);
                }
            }
            else
            {
                // Ingreso todas las filas del primer DataTable
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    DataRow newRow = table.NewRow();

                    // Busco el Row en el Segundo DataTable usando la clave primaria entregada
                    DataRow row2 = dataTable2.Rows.Cast<DataRow>().FirstOrDefault(r => r[columnaPrimaria].Equals(row1[columnaPrimaria]));

                    foreach (DataColumn column in table.Columns)
                    {
                        // Copio el valor del Row del Primer DataTable o del Segundo DataTable, según corresponda
                        if (dataTable1.Columns.Contains(column.ColumnName))
                        {
                            newRow[column.ColumnName] = row1[column.ColumnName];
                        }
                        else if (row2 != null)
                        {
                            newRow[column.ColumnName] = row2[column.ColumnName];
                        }
                    }
                    table.Rows.Add(newRow);
                }

                // Ingreso todas las filas del segundo DataTable
                foreach (DataRow row2 in dataTable2.Rows)
                {
                    // Busco si el Row ya fué ingresado en el primer DataTable
                    DataRow row = table.Rows.Cast<DataRow>().FirstOrDefault(r => r[columnaPrimaria].Equals(row2[columnaPrimaria]));

                    if (row == null)
                    {
                        DataRow newRow = table.NewRow();

                        // Busco el Row en el Primer DataTable usando la clave primaria entregada
                        DataRow row1 = dataTable1.Rows.Cast<DataRow>().FirstOrDefault(r => r[columnaPrimaria].Equals(row2[columnaPrimaria]));

                        foreach (DataColumn column in table.Columns)
                        {
                            // Copio el valor del Row del Primer DataTable o del Segundo DataTable, según corresponda
                            if (dataTable2.Columns.Contains(column.ColumnName))
                            {
                                newRow[column.ColumnName] = row2[column.ColumnName];
                            }
                            else if (row1 != null)
                            {
                                newRow[column.ColumnName] = row1[column.ColumnName];
                            }
                        }
                        table.Rows.Add(newRow);
                    }
                }
            }

            return table;
        }

        /// <summary>
        /// Convierte un <see cref="DataTable"/> a una Lista
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="columnaValor"></param>
        /// <returns></returns>
        public static List<object> ConvertToList(DataTable dataTable, string columnaValor)
        {
            if (!dataTable.Columns.Contains(columnaValor))
            {
                throw new DataException("El DataTable no contiene una columna con el nombre " + columnaValor);
            }

            return (from DataRow row in dataTable.Rows select row[columnaValor]).ToList();
        }

        /// <summary>
        /// Convierte una Lista en un <see cref="DataTable"/>
        /// </summary>
        /// <typeparam name="T">Tipo de Dato de la Lista</typeparam>
        /// <param name="list">Lista de Elementos</param>
        /// <param name="columnName">Nombre Columna</param>
        /// <returns><see cref="DataTable"/> creado a partir de la Lista </returns>
        public static DataTable ConvertFromList<T>(IEnumerable<T> list, string columnName)
        {
            DataTable table = new DataTable();
            table.Columns.Add(columnName, typeof (T));

            foreach (T element in list)
            {
                DataRow row = table.NewRow();
                row[columnName] = element;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
