using Curdoperation.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curdoperation.Data
{
    public class ApplicationsDb : DbContext
    {
        public ApplicationsDb(DbContextOptions options) : base(options)
        {
    
        }


        public DbSet<Employee> EmployeesInfo { get; set; }
    }


}
