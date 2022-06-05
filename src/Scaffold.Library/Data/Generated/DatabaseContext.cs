using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scaffold.Library.Models;

namespace Scaffold.Library.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calendar> Calendars { get; set; } = null!;
        public virtual DbSet<Meeting> Meetings { get; set; } = null!;
        public virtual DbSet<Reminder> Reminders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=4200;username=root;password=pasSworD;database=db_scaffold_efcore", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.ToTable("calendars");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Owner)
                    .HasMaxLength(100)
                    .HasColumnName("owner");
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.ToTable("meetings");

                entity.HasIndex(e => e.CalendarId, "ix_meetings_calendar_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CalendarId).HasColumnName("calendar_id");

                entity.Property(e => e.ChangedAt)
                    .HasMaxLength(6)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("changed_at");

                entity.Property(e => e.CreatedAt)
                    .HasMaxLength(6)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Description)
                    .HasMaxLength(800)
                    .HasColumnName("description");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.StartAt)
                    .HasMaxLength(6)
                    .HasColumnName("start_at");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.HasOne(d => d.Calendar)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.CalendarId)
                    .HasConstraintName("fk_meetings_calendars");
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.ToTable("reminders");

                entity.HasIndex(e => e.MeetingId, "ix_reminders_meeting_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");

                entity.Property(e => e.RemindBefore).HasColumnName("remind_before");

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.Reminders)
                    .HasForeignKey(d => d.MeetingId)
                    .HasConstraintName("fk_reminders_meetings");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
