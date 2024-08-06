using EduConnect.Domain.Common;

namespace EduConnect.Domain
{
    public class Instructor : BaseEntity
    {
        public string? Name { get; set; }
        public string? Degree { get; set; }
        public decimal? Salary { get; set; }
        public Guid? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Course> Courses { get; set; } = [];
        public ICollection<InstructorCourse> InstructorCourses { get; set; } = [];

    }
}
