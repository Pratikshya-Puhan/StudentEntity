using StudentEntity.Model;
using System.Data;
using System.Data.SqlClient;

namespace StudentEntity.Repository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCourses();
        Task<SingleCourse> GetCourse(int Id);
        Task<Course> Save(Course newCountry);

    }

    public class CourseRepository : ICourseRepository
    {
        private readonly IConfiguration _configuration;


        public CourseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Course>> GetCourses()
        { 
            List<Course> courses = new List<Course>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default").ToString()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tblCourse", connection)
                {
                    CommandType = CommandType.Text
                };

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        courses.Add( new Course()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = Convert.ToString(reader["Name"]),

                        });
                    }
                }
            }

            return courses;
        }

        public async Task<SingleCourse> GetCourse(int Id)
        {
            SingleCourse course = new SingleCourse();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SpGetCourse", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Id", Id));

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        course= new SingleCourse()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = Convert.ToString(reader["Name"]),
                           
                        };
                    }
                    while (await reader.NextResultAsync())
                    {
                        List<Student> students = new List<Student>();

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

                        course.student = students;
                    }
                }
            }

            return course;
        }

        public async Task<Course> Save(Course newCourse)
        {
            Course course = new Course();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SpSaveCourse", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Name", newCourse.Name));

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        course = new Course()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = Convert.ToString(reader["Name"]),
                            
                        };
                    }
                }
            }

            return course;
        }
    }
}


