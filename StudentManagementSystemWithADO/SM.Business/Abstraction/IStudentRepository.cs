using SM.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Business.Abstraction
{
    public interface IStudentRepository
    {
        public IEnumerable<StudentDetails> GetAllStudents();

        public StudentDetails GetStudentById(int id);

        public int AddStudent(StudentDetails student);

        public int UpdateStudent(StudentDetails student);

        public int DeleteStudentById(int id);   
    }
}
