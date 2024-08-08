using EduConnect.Domain.Commons;
using EduConnect.Domain.Entities.Common;
using System.Globalization;

namespace EduConnect.Domain.Entities
{
    public class Course : BaseEntity, ILocalizableCourse
    {
        public string? CourseName { get; set; }
        public string? CourseNameAr { get; set; }
        public int Duration { get; set; }
        public Guid? TopicId { get; set; }
        public Topic? Topic { get; set; }
        public ICollection<Student> Students { get; set; } = [];
        public ICollection<StudentCourse> StudentCourses { get; set; } = [];
        public ICollection<Instructor> Instructors { get; set; } = [];
        public ICollection<InstructorCourse> InstructorCourses { get; set; } = [];

        public List<string> GetLocalized()
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            if (cultureInfo.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return [CourseNameAr];

            return [CourseName];
        }
    }
}
