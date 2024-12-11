using Azure;
using Curdoperation.Data;
using Curdoperation.Domain;
using Curdoperation.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Curdoperation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeControllers : ControllerBase
    {
        public readonly IEmployeeService _employeeservice;
        public readonly ApplicationsDb _context;

        public EmployeeControllers(IEmployeeService employeeService, ApplicationsDb context
            )
        {
            _employeeservice = employeeService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            var result = await _employeeservice.GetEmployeeListAsync();

            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeDataRequestDTO employeDto)
        {
            var rersult = await _employeeservice.PostEmployeeAsync(employeDto);
            if (rersult.Success)
            {
                return Ok(rersult);
            }
            return BadRequest(rersult);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var emp = await _employeeservice.GetEmployeeByIdAsync(id);
            if (emp.Success)
            {
                return Ok(emp);
            }
            return BadRequest(emp);
        }

        [HttpPut]
        public async Task<IActionResult> Updateemployeeinfo(int id, [FromBody] EmployeeDataRequestDTO employeDto)
        {
            if (employeDto == null)
            {
                return BadRequest("emploeeDto id require ");
            }

            var result = await _employeeservice.UpdateEmployeeInfo(id, employeDto);

            if (!result.Success)
            {
                return NotFound(new
                {
                    Message = result.ErrorMessage
                });
            }

            return Ok(new
            {
                Message = result.ResultMessage,
                Data = result.Data
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response = await _employeeservice.DeleteEmployeeById(id);

            if (!response.Success)
            {
                return NotFound(new
                {
                    Message = response.ErrorMessage
                });
            }

            return Ok(new
            {
                Message = response.ResultMessage,
                Success = response.Data
            });
        }
    }
}

    
        
    