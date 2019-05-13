using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Security.Entity
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string ClaveAcceso { get; set; }
        public string RutUsuario { get; set; }
        public int NoticiInicio { get; set; }
        public string Tipo { get; set; }
        public int Instalacion { get; set; }
        public string UsuarioDominio { get; set; }

        public Usuario() { }

        public Usuario(int idUsuario, string nombres, string claveAcceso, string rutUsuario, int noticiInicio, string tipo)
        {
            IdUsuario = idUsuario;
            Nombres = nombres;
            ClaveAcceso = claveAcceso;
            RutUsuario = rutUsuario;
            NoticiInicio = noticiInicio;
            Tipo = tipo;
        }
        
    }
}
