using System;
using System.Collections.Generic;
using System.Linq;
using CompaniesOperations.API.Infrastructure;
using CompaniesOperations.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CompaniesOperations.API.Repository
{
    public class LeadRepository : ILeadRepository
    {
        private readonly CompaniesOperationsDbContext _context;
        private readonly IConfiguration _config;
        
        public LeadRepository(CompaniesOperationsDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config; 
        }
        public IEnumerable<Lead> getAllLeadsByOffice(int period, int officeId, int page = 1)
        {
            var itemsPerPage = _config.GetValue<int>("LeadsPerPage");
            var jump = (itemsPerPage * (page-1));
            return _context.Leads
            .Where(lead => lead.Period == period && lead.AssignedOfficce == officeId)
            .Skip(jump)
            .Take(itemsPerPage)
            .ToList();
        }

        public IEnumerable<Lead> getAllLeadsOfManager(int period, int officeId, string managerIdentity, int page = 1)
        {
            var itemsPerPage = _config.GetValue<int>("LeadsPerPage");
            var jump = (itemsPerPage * (page - 1));
            return _context.Leads
            .Include(l => l.Company)
            .Include(l => l.Managements)
            .Where(lead => lead.Period == period && lead.AssignedOfficce == officeId && lead.AssignedTo == managerIdentity)
            .Skip(jump)
            .Take(itemsPerPage)
            .ToList();
        }

        public IEnumerable<Lead> getAllLeadsOfManagerAndFilters(int period, int officeId, string managerIdentity, int parentState = 0, int childState = 0, string companyRut = null, int page = 1)
        {
            var itemsPerPage = _config.GetValue<int>("LeadsPerPage");
            var jump = (itemsPerPage * (page - 1));
            var returnRaw = _context.Leads
            .Include(l => l.Company)
            .Include(l => l.Managements)
            .Where(lead => lead.Period == period && lead.AssignedOfficce == officeId && lead.AssignedTo == managerIdentity);

            if(parentState > 0){
                returnRaw = returnRaw
                        .Where(lead => lead.Managements.Count() > 0 && lead.Managements.ToArray()[lead.Managements.Count() -1].Stats.Contains(parentState.ToString().PadLeft(3, '0')));
            }else if(parentState < 0){
                returnRaw = returnRaw
                        .Where(lead => lead.Managements.Count() == 0);
            }

            if(childState > 0){
                returnRaw = returnRaw
                        .Where(lead => lead.Managements.Count() > 0 && lead.Managements.ToArray()[lead.Managements.Count() - 1].Stats.Contains(childState.ToString().PadLeft(3, '0')));
            }

            if(companyRut != null){
                returnRaw = returnRaw
                        .Where(lead => lead.CompanyId.Contains(companyRut));
            }


            return returnRaw
                    .Skip(jump)
                    .Take(itemsPerPage).ToList();
        }

        public Lead getLeadById(int leadId)
        {
            return _context.Leads
                .Include(l => l.Managements)
                .Include(l => l.Company)
                .FirstOrDefault(ld => ld.Id == leadId);
        }
    }
}