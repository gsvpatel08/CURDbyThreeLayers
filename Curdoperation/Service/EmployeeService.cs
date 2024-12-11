using Curdoperation.Domain;
using Curdoperation.Repository;
using Curdoperation.Utilities;

namespace Curdoperation.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository _repository;

        public EmployeeService(IRepository repository)
        {
            _repository = repository;
        }

        public Task<ServiceResponse<bool>> DeleteEmployeeById(int id)
        {
            return _repository.DeleteEmployeeById(id);
        }

       

         async Task<ServiceResponse<Employee>> IEmployeeService.GetEmployeeByIdAsync(int id)
        {
         var result =  await  _repository.GetEmployeeById(id);
            return result;
        }

        async Task<ServiceResponse<List<Employee>>> IEmployeeService.GetEmployeeListAsync()
        {

            var result = await _repository.GetAllEmployee();

            return result;
        }

        Task<ServiceResponse<Employee>> IEmployeeService.PostEmployeeAsync(EmployeeDataRequestDTO employeeDtoo)
        {

           return  _repository.PostEmployee(employeeDtoo);
        }

       
        Task<ServiceResponse<Employee>> IEmployeeService.UpdateEmployeeInfo(int id, EmployeeDataRequestDTO employee)
        {

          var result =   _repository.UpdateEmployeeInfo(id, employee);
            return result;
        }
    }
    }

