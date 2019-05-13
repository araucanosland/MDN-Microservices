using System.Collections.Generic;
using System.Linq;
using CompaniesOperations.API.Infrastructure;
using CompaniesOperations.API.Model;

namespace CompaniesOperations.API.Repository
{
    public class ManagementStatsRepository : IManagementStatsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly CompaniesOperationsDbContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ManagementStatsRepository(CompaniesOperationsDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentStatId"></param>
        /// <returns></returns>
        public ManagementStats getParentStat(int parentStatId)
        {
            return _context.ManagementStats.FirstOrDefault(st => st.Id == parentStatId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leadTypeId"></param>
        /// <returns></returns>
        public IEnumerable<ManagementStats> getStatsByLeadType(int leadTypeId)
        {
            return _context.ManagementStats.Where(ms => ms.LeadTypeId == leadTypeId).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leadTypeId"></param>
        /// <returns></returns>
        public IEnumerable<ManagementStats> getStatsByLeadTypeOnlyChilds(int leadTypeId)
        {
           return _context.ManagementStats.Where(ms => ms.LeadTypeId == leadTypeId && ms.ParentId != null).ToList();       
        }

        
    }
}