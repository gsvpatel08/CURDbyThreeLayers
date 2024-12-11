using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curdoperation.Domain
{
    public class Employee
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public  required string empName { get; set; }

        public required string email { get; set; }

        public  string? phone { get; set; }

        public  decimal salary { get; set; }

    }
}
