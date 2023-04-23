using StudentEntity.Model;

namespace StudentEntity.Repository
{
    public class SingleCourse
    {
        public string? Name { get; internal set; }
        public int Id { get; internal set; }
        public List<Student> student { get; internal set; }
    }
}