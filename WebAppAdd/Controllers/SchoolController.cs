using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppAdd.Abstraction.IServices;
using WebAppAdd.Data;
using WebAppAdd.DTOs.SchoolDTOs;
using WebAppAdd.Entities;

namespace WebAppAdd.Controllers
{
    [Route("api")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly ILogger<SchoolController> _logger;  
        private readonly ISchoolService _schoolService;

        public SchoolController(ILogger<SchoolController> logger, ISchoolService schoolService)
        {
            _logger = logger;   
            _schoolService = schoolService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSchools()
        {
           // var data = await _schoolService.GetSc
            return Ok(/*SchoolDbModel.Select(SchoolDbModel => _mapper.map<SchoolDTO>(SchoolDbModel))*/);
        }

        [HttpPost]
        public async Task<IActionResult> AddSchool(SchoolGetDTO schoolDTO)
        {
            //var school = _mapper.Map<SchoolGetDTO>(schoolDTO);
            //SchoolDbModel.Add.School(school);
            return Ok(/*SchoolDbModel.Select(SchoolDbModel => _mapper.map<SchoolDTO>(SchoolDbModel))*/);

        }
    }
}
