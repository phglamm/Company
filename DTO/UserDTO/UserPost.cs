namespace Company.DTO.UserDTO
{
    public class UserPost
    {
        //public int Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public int DepartmentId { get; set; }
    }
}
