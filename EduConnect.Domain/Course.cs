using EduConnect.Domain.Common;

namespace EduConnect.Domain
{
    public class Course : BaseEntity
    {
        public string? CourseName { get; set; }
        public int Duration { get; set; }
        public Guid? TopicId { get; set; }
        public Topic? Topic { get; set; }
        public ICollection<Student> Students { get; set; } = [];
        public ICollection<StudentCourse> StudentCourses { get; set; } = [];
        public ICollection<Instructor> Instructors { get; set; } = [];
        public ICollection<InstructorCourse> InstructorCourses { get; set; } = [];
    }
}
