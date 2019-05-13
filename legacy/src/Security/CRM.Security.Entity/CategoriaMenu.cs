using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Security.Entity
{
    public class CategoriaMenu
    {
        public int CodCategoria { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public IEnumerable<MenuBase> Menus { get; set; }


        public CategoriaMenu()
        {
            Menus = new List<MenuBase>();
        }
    }
}
