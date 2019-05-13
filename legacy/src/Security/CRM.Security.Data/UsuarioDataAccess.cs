using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Security.Entity;
using System.Data;
using CDK.Data;
using CDK.Integration;

namespace CRM.Security.Data
{
    public static class UsuarioDataAccess
    {
        /*public static List<Usuario> ListarUsuarios()
        {
            return DBHelper.InstanceCRM.ObtenerColeccion("security.sp_SCA_ListarUsuarios", ConstructorEntidad);
        }*/

        public static Usuario UsuarioData(string RutUsuario)
        {
            Parametro p = new Parametro("@RutUsuario", RutUsuario);            
            return DBHelper.InstanceCRM.ObtenerEntidad("security.spSca_ObtenerUsuarioByRut", p, ConstructorEntidad);
        }

        public static Usuario UsuarioData(int IdUsuairo)
        {
            Parametro p = new Parametro("@IdUsuario", IdUsuairo);
            return DBHelper.InstanceCRM.ObtenerEntidad("security.spSca_ObtenerUsuario", p, ConstructorEntidad);
        }

        public static void InsertUsuario(Usuario usuario)
        {
            Parametros pEntrada = new Parametros()
            {
                new Parametro("@IdUsuario",usuario.IdUsuario),
                new Parametro("@Nombres",usuario.Nombres),
                new Parametro("@ClaveAcceso",usuario.ClaveAcceso),
                new Parametro("@RutUsuario",usuario.RutUsuario)
            };

            DBHelper.InstanceCRM.EjecutarProcedimiento("sp_SCA_InsetaUsuario", pEntrada);
        }

        private static Usuario ConstructorEntidad(DataRow row)
        {
            return new Usuario
            {
                IdUsuario = row["usr_id"] != DBNull.Value ? Convert.ToInt32(row["usr_id"]) : 0,
                Nombres = row["usr_nombre"] != DBNull.Value ? row["usr_nombre"].ToString() : string.Empty,
                ClaveAcceso = row["usr_clave"] != DBNull.Value ? row["usr_clave"].ToString() : string.Empty,
                RutUsuario = row["usr_rut"] != DBNull.Value ? row["usr_rut"].ToString() : string.Empty,
                NoticiInicio = row["usr_noticia_inicio"] != DBNull.Value ? Convert.ToInt32(row["usr_noticia_inicio"]) : 0,
                Tipo = row["usr_tipo"] != DBNull.Value ? row["usr_tipo"].ToString() : string.Empty,
                Instalacion = row["usr_instalacion"] != DBNull.Value ? Convert.ToInt32(row["usr_instalacion"]) : 0,
                UsuarioDominio = row["usr_dominio"] != DBNull.Value ? row["usr_dominio"].ToString() : string.Empty,
            };
        }
    }
}
