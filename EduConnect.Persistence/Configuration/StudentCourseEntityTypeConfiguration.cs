using EduConnect.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduConnect.Persistence.Configuration
{
    internal class StudentCourseEntityTypeConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(x => new { x.CourseId, x.StudentId });
            builder.ToTable("StudentCourses");
        }
    }
}
