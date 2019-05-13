using System;
using System.Collections.Generic;
using CompaniesOperations.API.Dto;
using CompaniesOperations.API.Model;
using CompaniesOperations.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CompaniesOperations.API.Controllers
{
    [Route("api/v1/managements")]
    [ApiController]
    public class ManagementsController : ControllerBase
    {
        private readonly IManagementRepository _managementRepo;

        public ManagementsController(IManagementRepository managementRepo)
        {
            _managementRepo = managementRepo;
        }

        [HttpGet("{leadId}")]
        public ActionResult<IEnumerable<Management>> Get([FromRoute] int leadId)
        {
            try{
                return Ok(
                   _managementRepo.getAllByLead(leadId)
                );
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public void Post([FromBody] PostManagementDto postObject)
        {
            Management management = new Management(
                postObject.leadId,
                postObject.comments,
                postObject.status.Parent,
                postObject.status.Child,
                postObject.nextAppointment,
                postObject.manager,
                postObject.office   
            );

            _managementRepo.addNewManagement(management);
            _managementRepo.SaveChanges();
        }
        
    }
}