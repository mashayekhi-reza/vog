using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VogCodeChallenge.ApplicationServices;
using VogCodeChallenge.Domain;

namespace VogCodeChallenge.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeService.GetAll();
        }

        [HttpGet("department/{departmentId}")]
        public IEnumerable<Employee> Get(Guid departmentId)
        {
            return _employeeService.GetByDepartment(departmentId);
        }        
    }
}
