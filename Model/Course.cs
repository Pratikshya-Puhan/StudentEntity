namespace StudentEntity.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class CreateCourseDTO : Course
    {
        public string Name { get; set; } = string.Empty;

    }
}
