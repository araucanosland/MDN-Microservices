using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Entity.Contracts
{
    public interface IResultado<T>
    {
        string Estado { get; set; }
        string Mensaje { get; set; }
        T Objeto { get; set; }
    }
}
