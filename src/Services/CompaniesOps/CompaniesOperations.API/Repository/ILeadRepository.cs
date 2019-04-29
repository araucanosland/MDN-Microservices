using System.Collections.Generic;
using CompaniesOperations.API.Model;

namespace CompaniesOperations.API.Repository
{
    public interface ILeadRepository
    {
        IEnumerable<Lead> getAllLeadsOfManager(int period, int officeId, string managerIdentity, int page = 1);
        IEnumerable<Lead> getAllLeadsByOffice(int period, int officeId, int page = 1);
        IEnumerable<Lead> getAllLeadsOfManagerAndFilters(int period, int officeId, string managerIdentity, int parentState = 0, int childState = 0, string companyRut = null, int page = 1);
        Lead getLeadById(int leadId);
    }
}