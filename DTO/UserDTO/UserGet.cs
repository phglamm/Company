using Company.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Company.DTO.DepartmentDTO;

namespace Company.DTO.UserDTO
{
    public class UserGet
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }
}
