using Microsoft.EntityFrameworkCore;
using SMSSModels;

namespace SMSSAPI.Data
{
    public class SMSSContext : DbContext
    {
        public SMSSContext(DbContextOptions<SMSSContext> options)
            : base(options)
        {
        }
        public DbSet<StaffDetails> StaffDetails { get; set; }
        public DbSet<ClassDetails> ClassDetails { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<SectionDetails> SectionDetails { get; set; }
        public virtual DbSet<SubjectDetails> SubjectDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffDetails>().ToTable("StaffDetails");
            modelBuilder.Entity<ClassDetails>().ToTable("ClassDetails");
            modelBuilder.Entity<States>().ToTable("States");
            modelBuilder.Entity<SectionDetails>().ToTable("SectionDetails");
            modelBuilder.Entity<SubjectDetails>().ToTable("SubjectDetails");

            modelBuilder.Entity<SectionDetails>(entity =>
            {
                entity.HasKey(e => e.SectionId);

                entity.Property(e => e.SectionName).HasMaxLength(100);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SectionDetails)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_SectionDetails_SectionDetails");
            });
            modelBuilder.Entity<SubjectDetails>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SubjectDetails)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_SubjectDetails_SubjectDetails");
            });
        }
    }
}
