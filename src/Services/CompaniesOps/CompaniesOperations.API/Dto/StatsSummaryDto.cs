namespace CompaniesOperations.API.Dto
{
    public class StatsSummaryDto
    {
        public string Code { get; set; }
        public string Leyend { get; set; }

        public StatsSummaryDto(string code, string leyend)
        {
            Code = code;
            Leyend = leyend;
        }

        public StatsSummaryDto(){}
    }
}