using AutoMapper;
using HRTool.Data;
using HRTool.Models.DTOs;
using HRTool.Models.Entities;
using HRTool.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController(IVacationRepository vacationRepository, IMapper mapper) : ControllerBase
    {
        private readonly IVacationRepository vacationRepository = vacationRepository;
        private readonly IMapper mapper = mapper;



        [HttpPost]
        public async Task<IActionResult> RequestVacation([FromBody] RequestVacationDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var vacationEntity = mapper.Map<Vacation>(dto);

                var newVacation = await vacationRepository.CreateVacationAsync(vacationEntity);
                var vacationDto = mapper.Map<Vacation>(newVacation);

                return CreatedAtAction(nameof(GetUserById), new { id = vacationDto.UserId }, vacationDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Cannot make a vacation request!");
            }

        }


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var vacation = await vacationRepository.GetVacationByIdAsync(id);

                if (vacation == null)
                {
                    return NotFound("Vacation not found");
                }

                var vacationDto = mapper.Map<VacationDto>(vacation);
                return Ok(vacationDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the vacation.");
            }
        }

    }
}
