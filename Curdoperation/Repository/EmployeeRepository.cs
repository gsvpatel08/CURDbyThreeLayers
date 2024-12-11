using Azure;
using Curdoperation.Data;
using Curdoperation.Domain;
using Curdoperation.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Curdoperation.Repository
{
    public class EmployeeRepository : IRepository
    {
        public readonly ApplicationsDb _Dbcontext;

        public EmployeeRepository(ApplicationsDb dbcontext)
        {
            _Dbcontext = dbcontext;
        }

        public async Task<ServiceResponse<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var result = await _Dbcontext.EmployeesInfo.FindAsync(id);

                return new ServiceResponse<Employee>
                {
                    Data = result,
                    Success = true,
                    ResultMessage = $"Employee #{id}"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Employee>
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                    ResultMessage = "There is some error finding emloyee no such data is present in database, try again!"
                };

            }

        }

        async Task<ServiceResponse<bool>> IRepository.DeleteEmployeeById(int id)
        {

            var response = new ServiceResponse<bool>();

            try
            {
                var employee = await _Dbcontext.EmployeesInfo.FindAsync(id);

                if (employee == null)
                {
                    response.Success = false;
                    response.Data = false;
                    response.ErrorMessage = $"Employee with ID {id} not found.";
                    return response;
                }

                _Dbcontext.EmployeesInfo.Remove(employee);
                await _Dbcontext.SaveChangesAsync();

                response.Success = true;
                response.Data = true;
                response.ResultMessage = "Employee deleted successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = false;
                response.ErrorMessage = $"An error occurred while deleting the employee: {ex.Message}";
            }

            return response;

        }

        async Task<ServiceResponse<List<Employee>>> IRepository.GetAllEmployee()
        {

            try
            {
                List<Employee> products = await _Dbcontext.EmployeesInfo.ToListAsync();

                return new ServiceResponse<List<Employee>>()
                {
                    Data = products,
                    Success = true,
                    ResultMessage = "Here is all your employes"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Employee>>()
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                    ResultMessage = "There is some error finding products, try again!"
                };
            }
        }
     

        async Task<ServiceResponse<Employee>> IRepository.UpdateEmployeeInfo(int id, EmployeeDataRequestDTO employeeDto)
        {
            var response = new ServiceResponse<Employee>();

            try
            {
                
                var existingEmployee = await _Dbcontext.EmployeesInfo.FindAsync(id);
                if (existingEmployee == null)
                {
                    response.Success = false;
                    response.ErrorMessage = $"Employee with ID {id} not found.";
                    return response;
                }

                existingEmployee.empName = employeeDto.empName;
                existingEmployee.email = employeeDto.email;
                existingEmployee.phone = employeeDto.phone;
                existingEmployee.salary = employeeDto.salary;


                 _Dbcontext.EmployeesInfo.Update(existingEmployee);
                await _Dbcontext.SaveChangesAsync();

                response.Success = true;
                response.Data = existingEmployee;
                response.ResultMessage = "Employee information updated successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = $"An error occurred while updating the employee: {ex.Message}";
            }

            return response;

        }
        async Task<ServiceResponse<Employee>> IRepository.PostEmployee(EmployeeDataRequestDTO employeeDto)
        {

            var response = new ServiceResponse<Employee>();

            try
            {

                var emp = new Employee
                {
                    empName = employeeDto.empName,
                    email = employeeDto.email,
                    phone = employeeDto.phone,
                    salary = employeeDto.salary,

                };
                await _Dbcontext.EmployeesInfo.AddAsync(emp);
                    await _Dbcontext.SaveChangesAsync();

                response.Success = true;
                response.Data = emp;
                response.ResultMessage = "Employee added successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = $"An error occurred while adding the employee: {ex.Message}";
            }

            return response;

        }
    }


}