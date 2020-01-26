using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MOQdigital.LHAntenatal.DataLayer.Model
{
    public partial class LiverpoolContext : DbContext
    {
        public LiverpoolContext()
        {
        }

        public LiverpoolContext(DbContextOptions<LiverpoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Geography> LHDGeography { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<MapPolygon> MapPolygon { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionGroup> QuestionGroup { get; set; }
        public virtual DbSet<QuestionText> QuestionText { get; set; }

        public virtual DbQuery<VW_GroupQuestion> VW_GroupQuestion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MD-R90Q8NH0\\LOCALSQL;Database=Liverpool;User Id=sa;Password=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Geography>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Language1).IsUnicode(false);

                entity.Property(e => e.ModifiedDateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<MapPolygon>(entity =>
            {
                entity.Property(e => e.Latitude).IsUnicode(false);

                entity.Property(e => e.Longitude).IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowVersion).IsRowVersion();

                entity.Property(e => e.SortOrder).IsUnicode(false);

                entity.HasOne(d => d.QuestionGroup)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.QuestionGroupId)
                    .HasConstraintName("FK_Question_QuestionGroup");
            });

            modelBuilder.Entity<QuestionGroup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ModifiedDateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowVersion).IsRowVersion();

                entity.Property(e => e.SortOrder).IsUnicode(false);
            });

            modelBuilder.Entity<QuestionText>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowVersion).IsRowVersion();

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionText)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionText_Question");
            });

            modelBuilder.Query<VW_GroupQuestion>().ToView("VW_GroupQuestion");
        }
    }
}
