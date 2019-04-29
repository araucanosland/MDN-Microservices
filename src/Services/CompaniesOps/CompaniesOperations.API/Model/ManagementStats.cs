namespace CompaniesOperations.API.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ManagementStats
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int? ParentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int LeadTypeId { get; set; }
        public LeadType LeadType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Options { get; set; }
    }
}