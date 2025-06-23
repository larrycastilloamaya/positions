using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hikru.Positions.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Position> Positions => Set<Position>();

        // ✅ Este método hace el mapeo directo a la tabla existente en Oracle
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().ToTable("POSITIONS_TB"); // importante: en mayúsculas
            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("POSITIONS_TB");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Title).HasColumnName("TITLE");
                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
                entity.Property(e => e.Location).HasColumnName("LOCATION");
                entity.Property(e => e.Status).HasColumnName("STATUS");
                entity.Property(e => e.RecruiterId).HasColumnName("RECRUITER_ID");
                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");
                entity.Property(e => e.Budget).HasColumnName("BUDGET");
                entity.Property(e => e.ClosingDate).HasColumnName("CLOSING_DATE");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
