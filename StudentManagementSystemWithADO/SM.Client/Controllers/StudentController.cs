using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.Business.Abstraction;
using SM.Business.Entities;

namespace SM.Client.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentRepository _Repository;
        public StudentController(IStudentRepository repository)
        {
            _Repository = repository;
        }

        [HttpGet]
        public IEnumerable<StudentDetails> Get()
        {
            return _Repository.GetAllStudents();
        }

        [HttpPost]
        public int Post([FromBody] StudentDetails student)
        {
            return _Repository.AddStudent(student);
        }

        [HttpGet]
        public StudentDetails GetStudentById(int id)
        {
            return _Repository.GetStudentById(id);
        }

        [HttpPut]
        public int Put([FromBody] StudentDetails student)
        {
            return _Repository.UpdateStudent(student);
        }

        [HttpDelete]
        public int Delete(int id)
        {
            return _Repository.DeleteStudentById(id);
        }
    }
}
