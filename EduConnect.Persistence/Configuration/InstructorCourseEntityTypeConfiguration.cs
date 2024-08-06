using EduConnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduConnect.Persistence.Configuration
{
    internal sealed class InstructorCourseEntityTypeConfiguration : IEntityTypeConfiguration<InstructorCourse>
    {
        public void Configure(EntityTypeBuilder<InstructorCourse> builder)
        {
            builder.HasKey(x => new { x.InstructorId, x.CourseId });
            builder.ToTable("InstructorCourses");
        }
    }
}
