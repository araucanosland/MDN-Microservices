using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Business.Entity;
using System.Data;
using CDK.Data;
using CDK.Integration;

namespace CRM.Business.Data.Mail
{
    public class DbMailDataAccess
    {
        public static EstadoMailEntity EnviaMail(string rutEjecutivo)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Rut", rutEjecutivo),

            };
            return DBHelper.InstanceMotorEmail.ObtenerEntidad("dbo.SP_MailContrasena", pram, EstEmail);
        }

        private static EstadoMailEntity EstEmail(DataRow row)
        {
            return new EstadoMailEntity
            {
                idEstadoMail = row["estado"] != DBNull.Value ? Convert.ToInt32(row["estado"]) : 0,
            };
        }

        public static int ActualizaContrasena(string Token, string pass)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Token", Token),
                new Parametro("@pass", pass),

            };
            return DBHelper.InstanceCRM.EjecutarProcedimiento("security.SPMotor_ActualizaContrasena", pram);
        }


        public static ContrasenaEntity EstadoContrasena(string Token)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@Token", Token),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("security.SPMotor_Estado_contrasena", pram, EstContrasena);
        }

        private static ContrasenaEntity EstContrasena(DataRow row)
        {
            return new ContrasenaEntity
            {
                estadoClave = row["usr_estado_clave"] != DBNull.Value ? Convert.ToInt32(row["usr_estado_clave"]) : 0,
            };
        }
    }
}
