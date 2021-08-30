using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VogCodeChallenge.API.DTOs;
using VogCodeChallenge.API.Helpers;
using VogCodeChallenge.ApplicationServices;

namespace VogCodeChallenge.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeMapper _mapper;
        
        public EmployeeController(IEmployeeService employeeService,
            IEmployeeMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> Get()
        {
            var employees = await _employeeService.GetAll();
            return _mapper.MapToDTO(employees);
        }

        [HttpGet("department/{departmentId}")]
        public async Task<IEnumerable<EmployeeDTO>> Get(Guid departmentId)
        {
            var employees = await _employeeService.GetByDepartment(departmentId);
            return _mapper.MapToDTO(employees);
        }        
    }
}
