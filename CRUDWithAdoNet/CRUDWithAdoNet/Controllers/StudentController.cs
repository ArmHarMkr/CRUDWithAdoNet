using CRUDWithAdoNet.Models;
using CRUDWithAdoNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithAdoNet.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentServices _studentService;
        public StudentController(IStudentServices studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public IActionResult StudentsList()
        {
            AllModels model = new AllModels();
            
            model.studentsList =  _studentService.GetStudentsRecord();
            return View(StudentsList);
        }
    }
}
