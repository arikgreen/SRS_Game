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
        public DbSet<Participant> Participants { get; set; }
        public DbSet<TeamParticipants> TeamParticipants { get; set; }
        public DbSet<MeetingHistoryFile> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<DocumentStakeholderRel> DocumentStakeholderRel {  get; set; }
        public DbSet<ProjectSpecification> ProjectSepcyfications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the unique constraint
            modelBuilder.Entity<Attachement>()
                .HasIndex(e => new { e.FileName, e.DocumentId })
                .IsUnique();

            modelBuilder.Entity<Document>()
                .HasIndex(e => new { e.Name, e.TeamLeaderId, e.Version })
                .IsUnique();

            modelBuilder.Entity<DocumentHistory>()
                .HasIndex(k => new { k.DocumentId, k.AuthorId, k.Version })
                .IsUnique();

            modelBuilder.Entity<Participant>()
                .HasIndex(k => new { k.Email, k.FirstName, k.LastName })
                .IsUnique();

            modelBuilder.Entity<Project>()
                .HasIndex(k => new { k.Name })
                .IsUnique();

            modelBuilder.Entity<Team>()
                .HasIndex(k => new { k.Name })
                .IsUnique();

            modelBuilder.Entity<MeetingHistoryFile>()
                .HasIndex(k => new { k.Id })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(k => new { k.Login, k.Email })
                .IsUnique();

            modelBuilder.Entity<UserRole>()
                .HasIndex(k => new { k.Name })
                .IsUnique();

            modelBuilder.Entity<TeamParticipants>()
                .HasKey(k => new { k.ParticipantId, k.TeamId });

            modelBuilder.Entity<DocumentStakeholderRel>()
                .HasKey(k => new { k.DocumentId, k.StakeholderId });

            modelBuilder.Entity<ProjectSpecification>()
                .HasKey(k => new { k.DocumentId, k.Version });
        }
    }
}