using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Security.Entity
{
    public class IdentidadLogin
    {
        public Usuario Usuario { get; set; }
        //public List<Recurso> Menus { get; set; }
        public bool EsSessionActiva { get; set; }
        public string Token { get; set; }

        public IdentidadLogin() { }

        /*public IdentidadLogin(Usuario usuario, List<Recurso> menus)
        {
            this.Usuario = usuario;
            this.Menus = menus;
        }

        public IdentidadLogin(Usuario usuario, List<Recurso> menus, string token)
        {
            this.Usuario = usuario;
            this.Menus = menus;
            this.Token = token; 
        }*/

        
    }
}
