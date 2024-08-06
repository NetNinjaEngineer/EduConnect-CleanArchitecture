using EduConnect.Domain;
using EduConnect.Persistence.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduConnect.Persistence.Configuration
{
    internal sealed class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.CourseName).HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(c => c.Topic)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TopicId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity<StudentCourse>(
                    left => left.HasOne(x => x.Student).WithMany(x => x.StudentCourses).HasForeignKey(x => x.StudentId),
                    right => right.HasOne(x => x.Course).WithMany(x => x.StudentCourses).HasForeignKey(x => x.CourseId)
                );

            builder.HasData(DatabaseHelper.GetCourses());

            builder.ToTable("Courses");
        }
    }
}
