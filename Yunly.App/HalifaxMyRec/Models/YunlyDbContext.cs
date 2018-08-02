using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Yunly.App.Crawler.HalifaxMyRec.Models
{
    public partial class YunlyDbContext : DbContext
    {
        public YunlyDbContext()
        {
        }

        public YunlyDbContext(DbContextOptions<YunlyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RecProgram> RecProgram { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=YunlyDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecProgram>(entity =>
            {
                entity.Property(e => e.Instructor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NextSessionStartDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NextSessionStartDateFormatted).HasColumnType("datetime");

                entity.Property(e => e.PaymentPlanTemplateId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StartDateFormatted).HasColumnType("datetime");

                entity.Property(e => e.WeekDays)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
