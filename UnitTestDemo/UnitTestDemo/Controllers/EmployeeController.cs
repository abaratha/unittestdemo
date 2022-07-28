using Business;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService; 
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _employeeService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            { 
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(Employee employee)
        {
            var result = await _employeeService.Save(employee);
            if(result > 0)
            {
                return Ok("Saved Successfully!");
            }
            else
            {
                return BadRequest("Error in save");
            }

        }
    }
}
