using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompaniesOperations.API.Dto;
using CompaniesOperations.API.Model;
using CompaniesOperations.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesOperations.API.Controllers
{
    [Route("api/v1/management-stats")]
    [ApiController]
    public class ManagementStatsController : ControllerBase
    {

        private readonly IManagementStatsRepository _managementStatsRepo;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="managementStatsRepo"></param>
        public ManagementStatsController(IManagementStatsRepository managementStatsRepo)
        {
            _managementStatsRepo = managementStatsRepo;            
        }

        /// <summary>
        /// Get all the 
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet("{leadTypeId}")]
        public ActionResult<IEnumerable<ManagementStats>> Get(
            [FromRoute] int leadTypeId
        )
        {
            return Ok(_managementStatsRepo.getStatsByLeadType(leadTypeId));
        }

        /// <summary>
        /// Get all the 
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet("{leadTypeId}/stats-map")]
        public ActionResult<IEnumerable<StatsSummaryDto>> GetStatsMap(
            [FromRoute] int leadTypeId
        )
        {
            List<StatsSummaryDto> returnList =  new List<StatsSummaryDto>();
            var loopCollection = _managementStatsRepo.getStatsByLeadTypeOnlyChilds(leadTypeId);
            foreach (var item in loopCollection)
            {
                var composedStat = new Management(item.ParentId.Value, item.Id).Stats;
                var parentStat = _managementStatsRepo.getParentStat(item.ParentId.Value);
                returnList.Add(new StatsSummaryDto(composedStat, composedStat + " - " + parentStat.Name + " / " + item.Name));
                
            }
            return Ok(returnList);
        }
    }
}
