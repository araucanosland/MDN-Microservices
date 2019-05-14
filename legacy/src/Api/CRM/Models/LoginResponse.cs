namespace CRM.Models
{
    public class LoginResponse
    {
        public string Rut { get; set; }
        public string Usuario { get; set; }
        public string Cargo { get; set; }
        public string Noticia { get; set; }
        public string Instalar { get; set; }
        public string Multi { get; set; }
        public string Oficina { get; set; }
        public string Token { get; set; }
        public int TokenExpiry { get; set; }
    }
}