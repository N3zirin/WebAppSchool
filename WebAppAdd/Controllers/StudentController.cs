using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppAdd.Abstraction.IServices;
using WebAppAdd.Data;
using WebAppAdd.Entities;

namespace WebAppAdd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _studentLogger;
        private readonly IStudentService _studentService;
        public StudentController(ILogger<StudentController> studentLogger, IStudentService studentService)
        {
            _studentLogger = studentLogger;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<Student> GetStudentId(int id)
        {
            return await _studentService.GetStudentId(1);
        }
        /*
       [HttpPost]
        public async Task<ActionResult> AddStudent(StudentDbModel std)
        {
           
            return View(std);   
        }
       

        [HttpGet("{ID}")]
        public async Task<ActionResult> GetStudent(int id)
        {
            
        }
       */
    }
}
