using Curdoperation.Domain;
using Curdoperation.Utilities;

namespace Curdoperation.Repository
{
     public interface IRepository
    {

        Task<ServiceResponse<List<Employee>>> GetAllEmployee();
        Task<ServiceResponse<Employee>> GetEmployeeById(int id );

        Task<ServiceResponse<Employee>> UpdateEmployeeInfo(int id ,EmployeeDataRequestDTO employee);

        Task<ServiceResponse<bool>> DeleteEmployeeById(int id);

        Task<ServiceResponse<Employee>> PostEmployee(EmployeeDataRequestDTO employeeDtoo);
    }
}
    

