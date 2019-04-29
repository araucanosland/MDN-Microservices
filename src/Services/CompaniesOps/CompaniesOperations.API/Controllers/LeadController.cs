using System;
using System.Collections.Generic;
using CompaniesOperations.API.Model;
using CompaniesOperations.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesOperations.API.Controllers
{
    [Route("api/v1/leads")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILeadRepository _leadRepo;
        public LeadController(ILeadRepository leadRepo)
        {
            _leadRepo = leadRepo;
        }

        [HttpGet("{officeId}/{userId}/{page}")]
        [HttpOptions]
        public ActionResult<IEnumerable<Lead>> Get(
            [FromRoute] int officeId, 
            [FromRoute] string userId, 
            [FromRoute] int page,
            [FromQuery] int parentState = 0,
            [FromQuery] int childState = 0,
            [FromQuery] string companyRut = null
        )
        {
            int period = Convert.ToInt32(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2,'0'));
            return Ok(
                _leadRepo.getAllLeadsOfManagerAndFilters(period, officeId, userId, parentState, childState, companyRut, page)
            );
        }

        [HttpGet("{leadId}")]
        public ActionResult<Lead> Get([FromRoute] int leadId)
        {
            return Ok(
                _leadRepo.getLeadById(leadId)
            );
        }
    }
}