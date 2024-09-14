using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Models;


namespace SRS_Game.Data
{
    public class SRS_GameDbContext : DbContext
    {
        public SRS_GameDbContext(DbContextOptions<SRS_GameDbContext> options)
            : base(options)
        {
        }

        public DbSet<Attachement> Attachements { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DocumentHistory> DocumentHistories { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ParticipantType> ParticipantTypes { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<TeamParticipants> TeamParticipants { get; set; }
        public DbSet<MeetingHistoryFile> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the unique constraint
            modelBuilder.Entity<Attachement>()
                .HasIndex(e => new { e.FileName, e.DocumentId })
                .IsUnique();

            modelBuilder.Entity<Document>()
                .HasIndex(e => new { e.Name, e.TeamLeaderId, e.VersionId })
                .IsUnique();

            modelBuilder.Entity<DocumentHistory>()
                .HasIndex(e => new { e.DocumentId, e.AuthorId, e.Version })
                .IsUnique();

            modelBuilder.Entity<Participant>()
                .HasIndex(a => new { a.Email, a.FirstName, a.LastName })
                .IsUnique();

            modelBuilder.Entity<Project>()
                .HasIndex(a => new { a.Name })
                .IsUnique();

            modelBuilder.Entity<ParticipantType>()
                .HasIndex(b => new { b.Name })
                .IsUnique();

            modelBuilder.Entity<Team>()
                .HasIndex(e => new { e.Name })
                .IsUnique();

            modelBuilder.Entity<MeetingHistoryFile>()
                .HasIndex(e => new { e.Id })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(a => new { a.Login, a.Email })
                .IsUnique();

            modelBuilder.Entity<UserRole>()
                .HasIndex(b => new { b.Name })
                .IsUnique();

            modelBuilder.Entity<TeamParticipants>()
                .HasKey(p => new { p.ParticipantId, p.TeamId });
        }
    }
}