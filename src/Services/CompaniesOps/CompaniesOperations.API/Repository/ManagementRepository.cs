using System;
using System.Collections.Generic;
using System.Linq;
using CompaniesOperations.API.Infrastructure;
using CompaniesOperations.API.Model;
using Microsoft.Extensions.Configuration;

namespace CompaniesOperations.API.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class ManagementRepository : IManagementRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly CompaniesOperationsDbContext _context;
        private readonly IConfiguration _config;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="config"></param>
        public ManagementRepository(CompaniesOperationsDbContext context, IConfiguration config){
            _context = context;
            _config = config;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="management"></param>
        public void addNewManagement(Management management)
        {
            _context.Managements.Add(management);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leadId"></param>
        /// <returns></returns>
        public IEnumerable<Management> getAllByLead(int leadId)
        {
            return _context.Managements.Where(mg => mg.LeadId == leadId).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<Management> getAllNextCommitments(int page = 1)
        {
            var itemsPerPage = _config.GetValue<int>("ManagementsPerPage");
            var jump = (itemsPerPage * (page - 1));
            return _context.Managements
                .Where(mn => mn.NextCommitment.HasValue && mn.NextCommitment >= DateTime.Now)
                .Skip(jump)
                .Take(itemsPerPage)
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxDate"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<Management> getAllNextCommitments(DateTime maxDate, int page = 1)
        {
            var itemsPerPage = _config.GetValue<int>("ManagementsPerPage");
            var jump = (itemsPerPage * (page - 1));
            return _context.Managements
                .Where(mn => mn.NextCommitment.HasValue 
                            && mn.NextCommitment >= DateTime.Now 
                            && mn.NextCommitment <= maxDate)
                .Skip(jump)
                .Take(itemsPerPage)
                .ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}