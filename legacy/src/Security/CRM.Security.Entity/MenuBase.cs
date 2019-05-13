using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Security.Entity
{
    public class MenuBase
    {
        public string Nombre { get; set; }
        public Menu MenuMetaData { get; set; }
        public CategoriaMenu Categoria { get; set; }
        public IEnumerable<MenuBase> Hijos { get; set; }
        

        public MenuBase()
        {
            MenuMetaData = new Menu();
        }   



    }
}
