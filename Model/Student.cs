namespace StudentEntity.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int CourseId{ get; set; } 
        public string PictureURL { get; set; }

    }
    public class CreateStudentDTO : Student
    {
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string PictureURL { get; set; }
        public object File { get; internal set; }
    }
}
