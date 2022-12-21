using SM.Business.Abstraction;
using SM.Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace SM.Data
{
    public class StudentRepository:IStudentRepository
    {
        string connectionString = "Server= IN-LT-17731\\SQL2019; Database= StudentManagement; Trusted_Connection=True;MultipleActiveResultSets=true;";

        //Student details Display    
        public IEnumerable<StudentDetails> GetAllStudents()
        {
            List<StudentDetails> ListStudent = new List<StudentDetails>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {
                    StudentDetails student = new StudentDetails();
                    student.StudentID = Convert.ToInt32(rdr["StudentID"]);
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.SchoolName = rdr["SchoolName"].ToString();
                    student.Gender = rdr["Gender"].ToString();
                    ListStudent.Add(student);
                }
                conn.Close();
            }
            return ListStudent;
        }

        //Create new Student   
        public int AddStudent(StudentDetails student)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@SchoolName", student.SchoolName);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return 1;
        }

        //Update student data from Student Id  
        public int UpdateStudent(StudentDetails student)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@SchoolName", student.SchoolName);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return 1;
        }

        // Find student data from Student Id
        public StudentDetails GetStudentById(int id)
        {
            StudentDetails student = new StudentDetails();



            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM StudentDetails WHERE StudentID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    student.StudentID = Convert.ToInt32(rdr["StudentID"]);
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.SchoolName = rdr["SchoolName"].ToString();
                    student.Gender = rdr["Gender"].ToString();
                }
            }
            return student;
        }

        // Delete student data from Student Id  
        public int DeleteStudentById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return 1;
        }
    }
}