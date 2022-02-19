using BlazoeProject.Contract;
using BlazoeProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazoeProject.Shared.Constants.GlobalVariables;

namespace BlazoeProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IUnitOfWork _db;

        public EmployeeController(ILogger<EmployeeController> logger, IUnitOfWork db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees(int skip = 0, int take = 5)
        {
            try
            {
                var employees = await _db.Employees.FindAllAsync(skip, take);

                return Ok(employees);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, INTERNAL_SERVER_ERROR);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _db.Employees.FindByIdAsync(id);

                if (employee != null)
                    return Ok(employee);

                return NotFound("The employee with that id number does not exixt");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, INTERNAL_SERVER_ERROR);
            }
        }
        [HttpPost()]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();

                var emp = _db.Employees.FindAll(c => c.Email == employee.Email);
                if (emp != null)
                {
                    ModelState.AddModelError(nameof(Employee.Email), "Employee email already exist");
                    return Conflict(ModelState); //duplicates
                }


                await _db.Employees.AddAsync(employee);
                await _db.SaveChanges();

                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, INTERNAL_SERVER_ERROR);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> Update(int id,Employee employee)
        {
            try
            {
                if (employee.Id !=id)
                    return BadRequest("Employee id mismatch");

                var emp = _db.Employees.FindByIdAsync(id);
                if (emp == null)
                {
                    return BadRequest($"Employee with id {id} not found");
                }


                _db.Employees.Update(employee);
                await _db.SaveChanges();

                return NoContent();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, INTERNAL_SERVER_ERROR);
            }
        }
    }
}
