using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Security.Entity
{
    public class UsuarioBase
    {
        public Usuario usuario { get; set; }
        //public IEnumerable<Grupo> grupos { get; set; }


        public UsuarioBase() { }

        /*public UsuarioBase(Usuario usr, IEnumerable<Grupo> grps)
        {
            usuario = usr;
            grupos = grps;
        }*/
    }
}
