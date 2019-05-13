using System;

namespace CompaniesOperations.API.Dto
{
    public class PostManagementDto
    {
        public int leadId { get; set; }
        public string comments { get; set; }
        public ManagementStatsDto status { get; set; }
        public DateTime? nextAppointment { get; set; }
        public string manager { get; set; }
        public int office { get; set; }

        public PostManagementDto()
        {
            status = new ManagementStatsDto();
        }
        
    }
}