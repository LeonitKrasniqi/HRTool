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


    }
}
