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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the user.");
            }
        }
    }

  
}

