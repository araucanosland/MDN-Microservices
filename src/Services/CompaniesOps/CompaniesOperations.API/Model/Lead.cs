using System;
using System.Collections.Generic;

namespace CompaniesOperations.API.Model
{
    /// <summary>
    /// Created By @Charlie
    /// </summary>
    public class Lead
    {
        /// <summary>
        /// 
        /// </summary>
        public Lead(){}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="period"></param>
        /// <param name="leadTypeId"></param>
        /// <param name="companyId"></param>
        /// <param name="companyName"></param>
        /// <param name="assignedOfiice"></param>
        /// <param name="assginedTo"></param>
        public Lead(int period, int leadTypeId, string companyId, string companyName, int assignedOfiice, string assginedTo)
        {
            Period = period;
            LeadTypeId = leadTypeId;
            CompanyId = companyId;
            AssignedOfficce = AssignedOfficce;
            AssignedTo = assginedTo;
            CreatedAt = DateTime.Now;
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
        public int Period { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int LeadTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public LeadType LeadType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string CompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Company Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int AssignedOfficce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AssignedTo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IEnumerable<Management> Managements { get; set;}

    }
}