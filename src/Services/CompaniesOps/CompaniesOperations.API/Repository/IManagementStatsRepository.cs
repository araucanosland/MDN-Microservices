using System;
using System.Collections.Generic;
using CompaniesOperations.API.Dto;
using CompaniesOperations.API.Model;

namespace CompaniesOperations.API.Repository
{
    public interface IManagementStatsRepository
    {
        IEnumerable<ManagementStats> getStatsByLeadType(int leadTypeId);
        IEnumerable<ManagementStats> getStatsByLeadTypeOnlyChilds(int leadTypeId);
        /// <summary>
        /// Obtener el Objeto padre del Stat Actual
        /// </summary>
        /// <param name="parentStatId">Identificador del padre del buscado</param>
        /// <returns>retorna un objecto MAnagementStats el cual representa al pradre del id solicitado</returns>
        ManagementStats getParentStat(int parentStatId);
    }
}