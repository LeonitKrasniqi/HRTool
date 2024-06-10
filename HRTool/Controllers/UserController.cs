using AutoMapper;
using HRTool.Models.DTOs;
using HRTool.Models.Entities;
using HRTool.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository userRepository, IMapper mapper) : ControllerBase
    {
        private readonly IUserRepository userRepository = userRepository;
        private readonly IMapper mapper = mapper;


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userEntity = mapper.Map<User>(dto);

                var newUser = await userRepository.CreateUserAsync(userEntity);
                var userDto = mapper.Map<User>(newUser);

                return CreatedAtAction(nameof(GetUserById), new { id = userDto.UserId }, userDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Cannot create a user! ");
            }

        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await userRepository.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                var userDto = mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the user.");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await userRepository.GetAllAsync();
                var userDtos = mapper.Map<List<UserDto>>(users);
                return Ok(userDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching users.");
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var result = await userRepository.DeleteAsync(id);

                if (!result)
                {
                    return NotFound("User not found");
                }

                return Ok("User deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the user.");
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingUser = await userRepository.GetByIdAsync(id);
                if (existingUser == null)
                {
                    return NotFound("User not found");
                }

                mapper.Map(dto, existingUser);

                await userRepository.UpdateAsync(existingUser);

                return Ok(new { user = existingUser, message = "User updated" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the user.");
            }
        }
    }

  
}

