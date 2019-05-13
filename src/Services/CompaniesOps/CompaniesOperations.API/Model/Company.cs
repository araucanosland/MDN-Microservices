using System.Collections.Generic;

namespace CompaniesOperations.API.Model
{
    public class Company
    {
        /// <summary>
        /// Rut Compuesto de la Empresa
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Rut de la Empresa
        /// </summary>
        public int CompanyRut { get; set; }
        /// <summary>
        /// Digito verificador de la empresa
        /// </summary>
        /// <value></value>
        public string CompanyDv { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string CompanyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Segment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Address { get; set; }
        /// <summary>
        /// City of the Company
        /// </summary>
        /// <value></value>
        public string City { get; set; }
        /// <summary>
        /// Cantidad de Empleados de la empresa
        /// </summary>
        /// <value></value>
        public int EmployeesCount { get; set; }
        /// <summary>
        /// Meses sin Cotizar con la caja
        /// </summary>
        /// <value></value>
        public int UnlistedMonthsCount { get; set; }
        /// <summary>
        /// Ultimo periodo de Cotizacion de la empresa
        /// </summary>
        /// <value></value>
        public int LastViewPeriod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<Lead> Leads { get; set; }


    }
}