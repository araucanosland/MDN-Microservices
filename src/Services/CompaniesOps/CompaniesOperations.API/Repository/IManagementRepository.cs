using System;
using System.Collections.Generic;
using CompaniesOperations.API.Model;

namespace CompaniesOperations.API.Repository
{
    public interface IManagementRepository
    {
        IEnumerable<Management> getAllByLead(int leadId);
        IEnumerable<Management> getAllNextCommitments(int page = 1);
        IEnumerable<Management> getAllNextCommitments(DateTime maxDate, int page=1);
        /// <summary>
        /// Agregar nueva gestion de ejectivos de sucursal
        /// </summary>
        /// <param name="management">Modelo de Gestion</param>
        void addNewManagement(Management management);

        int SaveChanges();

    }
}