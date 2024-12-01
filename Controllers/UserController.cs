using Company.DTO.UserDTO;
using Company.Interface;
using Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;


        public UserController(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGet>>> GetAllUser()
        {
            var Users = await _userRepository.GetAllUsersAsync();

            var UserDTOs = Users.Select(c => new UserGet
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                Username = c.Username,
                Password = c.Password,
                DepartmentId = c.DepartmentId,
                DepartmentName = c.Department.DepartmentName
            }).ToList();

            return Ok(UserDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("There is no Department");
            }
            var userDTO = new UserGet
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Username = user.Username,
                Password = user.Password,
                DepartmentId = user.DepartmentId,
                DepartmentName = user.Department.DepartmentName
            };

            return Ok(userDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var deleteUser = await _userRepository.GetUserByIdAsync(id);
            if (deleteUser == null)
            {
                return NotFound("There is no User");
            }

            await _userRepository.DeleteUserAsync(id);
            return Ok("Delete Successfully");
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] UserPost userPost)
        {
            var addUser = new User
            {
                Name = userPost.Name,
                Age = userPost.Age,
                Username = userPost.Username,
                Password = userPost.Password,
                DepartmentId = userPost.DepartmentId,
            };

            var addedUser = await _userRepository.AddUserAsync(addUser);
            return CreatedAtAction(nameof(GetUserById), new { id = addedUser.Id }, addedUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutDepartment(int id, [FromBody] UserPost userPost)
        {
            var updateUser = await _userRepository.GetUserByIdAsync(id);
            if (updateUser == null)
            {
                return NotFound("There is no Department");
            }
            updateUser.Name = userPost.Name;
            updateUser.Age = userPost.Age;
            updateUser.Username = userPost.Username;
            updateUser.Password = userPost.Password;
            updateUser.DepartmentId = userPost.DepartmentId;

            await _userRepository.UpdateUserAsync(updateUser);
            return (updateUser);
        }

    }
}
