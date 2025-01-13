using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services;
using CodeChallenge.Models;
using CodeChallenge.Data;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            _logger.LogDebug($"Received employee create request for '{employee.FirstName} {employee.LastName}'");

            _employeeService.Create(employee);

            return CreatedAtRoute("getEmployeeById", new { id = employee.EmployeeId }, employee);
        }

        [HttpGet("{id}", Name = "getEmployeeById")]
        public IActionResult GetEmployeeById(String id)
        {
            _logger.LogDebug($"Received employee get request for '{id}'");

            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceEmployee(String id, [FromBody]Employee newEmployee)
        {
            _logger.LogDebug($"Recieved employee update request for '{id}'");

            var existingEmployee = _employeeService.GetById(id);
            if (existingEmployee == null)
                return NotFound();

            _employeeService.Replace(existingEmployee, newEmployee);

            return Ok(newEmployee);
        }


        //new code starts here

        // get reporting structure by id
        [HttpGet("{id}", Name = "getGetReportingStructureById")]
        public ActionResult<ReportingStructure> GetReportingStructureById(string id)
        {
            _logger.LogDebug("Received employee create request for id [{Id}]", id);
            Employee employee = _employeeService.GetById    (id);
            if (employee == null)
            {
                return NotFound();
            }

            ReportingStructure reportingStruct = new ReportingStructure(employee);
            reportingStruct.setNumberOfReports(GetReportingStructure(employee) - 1);
            return reportingStruct;
        }

        //recursive function to visit all reporting employees
        private int GetReportingStructure(Employee employee)
        {
            if (employee.DirectReports == null || employee.DirectReports.Count == 0)
            {
                return 1;
            }

            int count = 1;
            foreach (var directReport in employee.DirectReports)
            {
                count += GetReportingStructure(directReport);
            }

            return count;
        }
    }
}


