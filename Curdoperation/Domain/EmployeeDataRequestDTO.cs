namespace Curdoperation.Domain
{
    public class EmployeeDataRequestDTO
    {
        public required string empName { get; set; }

        public required string email { get; set; }

        public string? phone { get; set; }

        public decimal salary { get; set; }
    }
}
