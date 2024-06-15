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
        public SRS_GameDbContext (DbContextOptions<SRS_GameDbContext> options)
            : base(options)
        {
        }

        public DbSet<Attachement> Attachements { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DocumentHistory> DocumentHistories { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<MeetingHistoryFile> Files { get; set; }

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
                .HasIndex(e => new { e.DocId, e.AuthorId, e.Version })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(a => new { a.Email, a.FirstName, a.LastName })
                .IsUnique();

            modelBuilder.Entity<Project>()
                .HasIndex(a => new { a.Name })
                .IsUnique();

            modelBuilder.Entity<UserType>()
                .HasIndex(b => new { b.Name })
                .IsUnique();

            modelBuilder.Entity<Team>()
                .HasIndex(e => new { e.Name })
                .IsUnique();

            modelBuilder.Entity<MeetingHistoryFile>()
                .HasIndex(e => new { e.Id })
                .IsUnique();
        }
    }
}