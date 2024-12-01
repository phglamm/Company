using Company.DTO.UserDTO;
using Company.Models;

namespace Company.DTO.DepartmentDTO
{
    public class DepartmentGet
    {
        public int DepartmentId { get; set; }
        public required string DepartmentName { get; set; }
        public List<string> UsersInDepartment { get; set; }  // List of usernames in the department

    }
}
