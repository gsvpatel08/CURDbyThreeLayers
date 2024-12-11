using Curdoperation.Domain;
using Curdoperation.Utilities;

namespace Curdoperation.Service
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<Employee>>> GetEmployeeListAsync();
        Task<ServiceResponse<Employee>> PostEmployeeAsync(EmployeeDataRequestDTO employeeDtoo);
        Task<ServiceResponse<Employee>> GetEmployeeByIdAsync(int id);

        Task<ServiceResponse<Employee>> UpdateEmployeeInfo(int id, EmployeeDataRequestDTO employee);
        Task<ServiceResponse<bool>> DeleteEmployeeById(int id);

    }
}
