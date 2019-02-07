using Microsoft.EntityFrameworkCore;
using Temp.Repository.Entities;
namespace Temp.Repository
{
    public partial class LockTestContext : DbContext
    {
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=server;Initial Catalog=catalog;Persist Security Info=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Descr)
                    .IsRequired()
                    .HasColumnType("nvarchar(4000)")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Question");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.Descr).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Descr)
                    .IsRequired()
                    .HasColumnType("nvarchar(4000)")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_File");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Descr).HasMaxLength(500);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UserPrincipalName)
                    .IsRequired()
                    .HasMaxLength(500);
            });
        }
    }
}
