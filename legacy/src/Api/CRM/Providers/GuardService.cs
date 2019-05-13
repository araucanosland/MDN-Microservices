using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using CRM.Security.Data;
using CRM.Security.Entity;

namespace CRM.Providers
{
    public class GuardService
    {
        public bool ValidarPermisos(string token, string controlador, string accion)
        {
            return false;
        }
    }
}