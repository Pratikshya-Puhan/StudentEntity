using StudentEntity.Model;
using System.Data;
using System.Data.SqlClient;

namespace StudentEntity.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<SingleStudent> GetStudents(int Id);
        Task<Student> Save(Student newStudent);

    }

    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _configuration;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Student>> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tblStudent", connection)
                {
                    CommandType = CommandType.Text
                };


                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        students.Add(new Student()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = Convert.ToString(reader["Name"]),
                            Gender = Convert.ToString(reader["Gender"]),
                            City = Convert.ToString(reader["City"]),
                            CourseId = Convert.ToInt32(reader["CourseId"]),
                            PictureURL = Convert.ToString(reader["PictreURL"])
                        });
                    }
                }
            }

            return students;
        }

        public Task<SingleStudent> GetStudents(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> Save(Student newStudent)
        {
            throw new NotImplementedException();
        }
    }
}
