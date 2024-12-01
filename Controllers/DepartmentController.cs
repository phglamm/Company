using Company.DTO.UserDTO;
using Company.Interface;
using Company.Models;
using Company.Repository;
using Microsoft.AspNetCore.Mvc;
using Company.DTO.DepartmentDTO;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Authorization;
namespace CountryAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentGet>>> GetAllDepartment()
        {
            var Departments = await _departmentRepository.GetAllDepartmentAsync();
            var DepartmentsDTO = Departments.Select(c => new DepartmentGet
            {
                DepartmentId = c.DepartmentId,
                DepartmentName = c.DepartmentName,
                UsersInDepartment = c.Users.Select(u => u.Username).ToList(),

            }).ToList();

            return Ok(DepartmentsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentGet>> GetDepartmentById(int id)
        {
            var Departments = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (Departments == null)
            {
                return NotFound("There is no Department");
            }
            var DepartmentsDTO = new DepartmentGet
            {
                DepartmentId = Departments.DepartmentId,
                DepartmentName = Departments.DepartmentName,
                UsersInDepartment = Departments.Users.Select(u => u.Username).ToList()
            };

            return Ok(DepartmentsDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var deleteDepartment = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (deleteDepartment == null)
            {
                return NotFound("There is no Department");
            }

            await _departmentRepository.DeleteDepartmentAsync(id);
            return Ok("Delete Successfully");
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment([FromBody] DepartmentPost departmentPost)
        {
            var addDepartment = new Department
            {
                DepartmentName = departmentPost.DepartmentName,
            };
        
            var addedDepartment = await _departmentRepository.AddDepartmentAsync(addDepartment);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = addedDepartment.DepartmentId }, addedDepartment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> PutDepartment(int id, [FromBody] DepartmentPost departmentPost)
        {
            var updateDepartment = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (updateDepartment == null)
            {
                return NotFound("There is no Department");
            }
            updateDepartment.DepartmentName = departmentPost.DepartmentName;

            await _departmentRepository.UpdateDepartmentAsync(updateDepartment);
            return (updateDepartment);
        }

    }
}
