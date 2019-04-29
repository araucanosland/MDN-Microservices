using System.Collections.Generic;

namespace CompaniesOperations.API.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class LeadType
    {
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="id">Id de la Entidad</param>
        /// <param name="name">Nombre de la Entidad</param>
        public LeadType(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<Lead> Leads { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<ManagementStats> ManagementStats { get; set; }
    }
}