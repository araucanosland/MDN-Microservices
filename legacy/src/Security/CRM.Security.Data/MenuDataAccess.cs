using System;
using System.Collections.Generic;
using System.Data;
using CRM.Security.Entity;
using CDK.Integration;
using CDK.Data;

//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace CRM.Security.Data
{
    /// <summary>
    /// Clase Acceso de Datos MenuDataAccess
    /// </summary>
    /// <author>@Charly</author>
    /// <created>14-09-2017 11:30:32</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// </remarks>
    public class MenuDataAccess
    {
        #region metodos Menu

        /// <summary>
        /// Guarda la entidad de dominio <see cref="Menu"/> en la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>14-09-2017 11:30:32</created>
        /// <param name="menu">Referencia a una clase <see cref="Menu"/>.</param>
        /// <returns>Clave primaria resultante de la operación</returns>
        public static int Guardar(Menu menu)
        {
            Parametros parametros = new Parametros
            {
                new Parametro("@CodMenu", menu.CodMenu),
                new Parametro("@CodRecurso", menu.CodRecurso),
                new Parametro("@CodMenuPadre", menu.CodMenuPadre),
                new Parametro("@Enlace", menu.Enlace),
                new Parametro("@Icono", menu.Icono),

            };

            return DBHelper.InstanceCRM.ObtenerEscalar<int>("security.sp_Sca_Menu_Guardar", parametros);
        }

        /// <summary>
        /// Recupera una entidad <see cref="Menu"/> de la Base de Datos dado un ID de Menu
        /// </summary>
        /// <author>@Charly</author>
        /// <created>14-09-2017 11:30:32</created>
        /// <param name="CodMenu">ID de Menu.</param>
        /// <returns>Referencia a una clase <see cref="Menu"/>.</returns>
        public static Menu ObtenerPorID(int CodMenu)
        {
            Parametro parametro = new Parametro("@CodMenu", CodMenu);

            return DBHelper.InstanceCRM.ObtenerEntidad("security.sp_Sca_Menu_ObtenerPorID", parametro, ConstructorEntidad);
        }

        /// <summary>
        /// Lista todas las entidades <see cref="Menu"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>14-09-2017 11:30:32</created>
        /// <returns><see cref="DataTable"/> con todos los objetos.</returns>
        public static DataTable Listar()
        {
            return DBHelper.InstanceCRM.ObtenerDataTable("security.sp_Sca_Menu_Listar");
        }

        /// <summary>
        /// Recupera todas las entidades <see cref="Menu"/> de la Base de Datos
        /// </summary>
        /// <author>@Charly</author>
        /// <created>14-09-2017 11:30:32</created>
        /// <returns>Lista con todas las entidades <see cref="Menu"/>.</returns>
        public static List<Menu> ObtenerEntidades()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("security.sp_Sca_Menu_Listar", ConstructorEntidad);
        }

        #endregion

        #region metodos MenuBase

        public static List<MenuBase> ListarPadresByCategoria(int codCategoria, string Token)
        {
            Parametros prms = new Parametros()
            {
                new Parametro("@codCategoria", codCategoria),
                new Parametro("@Token", Token),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("security.sp_Sca_Menu_ListarPadresByCategoria", prms, ConstructorEntidadBase);
        }


        public static List<MenuBase> ListarHijos(int codPadre, string Token)
        {
            if(codPadre > 0)
            {
                Parametros prms = new Parametros()
                {
                    new Parametro("@codPadre", codPadre),
                    new Parametro("@Token", Token),
                };
                return DBHelper.InstanceCRM.ObtenerColeccion("security.sp_Sca_Menu_ListarHijos", prms, ConstructorEntidadBase);
            }
            else
            {
                return new List<MenuBase>();
            }
            
        }


        public static List<CategoriaMenu> ListarCategorias(string token)
        {
            Parametro pr = new Parametro("@Token", token);
            return DBHelper.InstanceCRM.ObtenerColeccion("security.sp_Sca_Menu_ListarCategorias", pr, ConstructorCategoria);
        }

        #endregion

        #region constructor
        private static Menu ConstructorEntidad(DataRow row)
        {
            return new Menu
            {
                CodMenu = row["CodMenu"] != DBNull.Value ? Convert.ToInt32(row["CodMenu"]) : 0,
                CodRecurso = row["CodRecurso"] != DBNull.Value ? Convert.ToInt32(row["CodRecurso"]) : 0,
                CodMenuPadre = row["CodMenuPadre"] != DBNull.Value ? Convert.ToInt32(row["CodMenuPadre"]) : 0,
                Enlace = row["Enlace"] != DBNull.Value ? row["Enlace"].ToString() : string.Empty,
                Icono = row["Icono"] != DBNull.Value ? row["Icono"].ToString() : string.Empty,
                Orden = row["Orden"] != DBNull.Value ? Convert.ToInt32(row["Orden"]) : 0,
                CodCategoria = row["CodCategoria"] != DBNull.Value ? Convert.ToInt32(row["CodCategoria"]) : 0,
            };
        }

        private static MenuBase ConstructorEntidadBase(DataRow row)
        {
            return new MenuBase
            {
                Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                MenuMetaData = ObtenerPorID(row["CodMenu"] != DBNull.Value ? Convert.ToInt32(row["CodMenu"]) : 0),
                Hijos = ListarHijos((row["CodMenu"] != DBNull.Value ? Convert.ToInt32(row["CodMenu"]) : 0), (row["Token"] != DBNull.Value ? row["Token"].ToString() : string.Empty))
            };
        }

        private static CategoriaMenu ConstructorCategoria(DataRow row)
        {
            return new CategoriaMenu
            {
                CodCategoria = row["CodCategoria"] != DBNull.Value ? Convert.ToInt32(row["CodCategoria"]) : 0,
                Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                Orden = row["Orden"] != DBNull.Value ? Convert.ToInt32(row["Orden"]) : 0,
                Menus = ListarPadresByCategoria((row["CodCategoria"] != DBNull.Value ? Convert.ToInt32(row["CodCategoria"]) : 0), (row["Token"] != DBNull.Value ? row["Token"].ToString() : string.Empty))
            };
        }
        #endregion
    }
}
