using System.Collections.Generic;

namespace CompaniesOperations.API.Infrastructure.ActionResults
{
    public class PagedResult<T> where T : class
    {
        public int PagesCount { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}