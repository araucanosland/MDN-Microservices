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
    public static class TokenDataAccess
    {
        public static List<Token> Obtener(string AuthToken)
        {
            Parametro p = new Parametro("@AuthToken", AuthToken);
            return DBHelper.InstanceCRM.ObtenerColeccion("security.spSca_DatosToken", p, ConstructorEntidad);
        }

        public static int Insertar(Token tok)
        {
            Parametros p = new Parametros()
            {
                new Parametro("@UserId",tok.UserId),
                new Parametro("@AuthToken",tok.AuthToken),
                new Parametro("@IssuedOn",tok.IssuedOn),
                new Parametro("@ExpiresOn",tok.ExpiresOn),
            };

            return DBHelper.InstanceCRM.EjecutarProcedimiento("security.spSca_InsertDatosToken", p);
        }

        public static int Actualizar(Token tok)
        {
            Parametros p = new Parametros()
            {
                new Parametro("@TokenId", tok.TokenId),
                new Parametro("@UserId",tok.UserId),
                new Parametro("@AuthToken",tok.AuthToken),
                new Parametro("@IssuedOn",tok.IssuedOn),
                new Parametro("@ExpiresOn",tok.ExpiresOn),
            };

            return DBHelper.InstanceCRM.EjecutarProcedimiento("security.spSca_ActualizaDatosToken", p);
        }


        public static int Eliminar(string idToken )
        {
            Parametro p = new Parametro("@AuthToken", idToken);
            return DBHelper.InstanceSecurity.EjecutarProcedimiento("security.spSca_EliminaToken", p);
        }

        public static int EliminarByUsuario(string IdUsuario)
        {
            Parametro p = new Parametro("@UserId", IdUsuario);
            return DBHelper.InstanceCRM.EjecutarProcedimiento("security.spSca_EliminaTokenByUsuario", p);
        }

        private static Token ConstructorEntidad(DataRow row)
        {
            return new Token
            {
                UserId = row["UserId"] != DBNull.Value ? Convert.ToInt32(row["UserId"]) : 0,
                TokenId = row["TokenId"] != DBNull.Value ? Convert.ToInt32(row["TokenId"]) : 0,
                AuthToken = row["AuthToken"] != DBNull.Value ? row["AuthToken"].ToString() : string.Empty,
                IssuedOn = row["IssuedOn"] != DBNull.Value ? Convert.ToDateTime(row["IssuedOn"]) : DateTime.MinValue,
                ExpiresOn = row["ExpiresOn"] != DBNull.Value ? Convert.ToDateTime(row["ExpiresOn"]) : DateTime.MinValue,
            };
        }
    }
}
