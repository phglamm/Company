using System.ComponentModel.DataAnnotations;
namespace Company.Models
{
    public partial class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public required string DepartmentName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
