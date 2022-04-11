using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using MyIT.Contracts;

namespace MyIT.DataAccess.Utils
{
    public class MyITDbContext : DbContext
    {
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<SessionComments> SessionComments { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<PsychologistSpeciality> PsychologistSpecialities { get; set; }
        public virtual DbSet<Psychologist> Psychologists { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<EducationalProgram> EducationalPrograms { get; set; }
        public virtual DbSet<AssignedStudentTest> AssignedStudentTests { get; set; }

        public MyITDbContext(DbContextOptions<MyITDbContext> options)
            : base(options)
        {
        }
    }
}
