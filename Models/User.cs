using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Company.Models
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }


    }
}
