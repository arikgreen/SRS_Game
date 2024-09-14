using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SRS_Game.Models;
using System.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using SRS_Game.Data;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SRS_GameDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any records.
            if (context.ParticipantTypes.Any())
            {
                //return;   // DB has been seeded
                context.ParticipantTypes.ExecuteDelete();
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('ParticipantTypes', RESEED, 0)");
                context.SaveChanges();
            }

            if (context.Teams.Any())
            {
                context.Teams.ExecuteDelete();
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Teams', RESEED, 0)");
                context.SaveChanges();
            }

            if (context.Participants.Any())
            {
                context.Participants.ExecuteDelete();
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Participants', RESEED, 0)");
                context.SaveChanges();
            }

            if (context.TeamParticipants.Any())
            {
                context.TeamParticipants.ExecuteDelete();
                context.SaveChanges();
            }

            if (context.Projects.Any())
            {
                context.Projects.ExecuteDelete();
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Projects', RESEED, 0)");
                context.SaveChanges();
            }

            if (context.Documents.Any())
            {
                context.Documents.ExecuteDelete();
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Documents', RESEED, 0)");
                context.SaveChanges();
            }

            if (context.DocumentHistories.Any())
            {
                context.DocumentHistories.ExecuteDelete();
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('DocumentHistories', RESEED, 0)");
                context.SaveChanges();
            }

            if (context.Attachements.Any())
            {
                context.Attachements.ExecuteDelete();
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Attachements', RESEED, 0)");
                context.SaveChanges();
            }

            if (context.UserRoles.Any())
            {
                context.UserRoles.ExecuteDelete();
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('UserRoles', RESEED, 0)");
                context.SaveChanges();
            }

            if (context.Users.Any())
            {
                context.Users.ExecuteDelete();
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Users', RESEED, 0)");
                context.SaveChanges();
            }

            var userRoles = new UserRole[]
            {
                new ("Administrator", "Administrator"),
                new ("Owner", "Teacher"),
                new ("User", "Student")
            };
            context.UserRoles.AddRange(userRoles);
            context.SaveChanges();

            var users = new User[]
            {
                new ("s94089", "", "s94089@student.pg.edu.pl", 3, "Artur", "Wilczak", "")
            };

            var teams = new Team[]
            {
                new ("Zespół A", "001"),
                new ("Zespół B", "002"),
                new ("Zespół C", "003"),
                new ("Zespół D", "004")
            };
            context.Teams.AddRange(teams);
            context.SaveChanges();

            var projects = new Project[] {
                new ("Projekt A", "PROJ001", new DateTime(2023, 1, 15), new DateTime(2023, 5, 15), 1),
                new ("Projekt B", "PROJ002", new DateTime(2023, 2, 20), new DateTime(2023, 6, 20), 2),
                new ("Projekt C", "PROJ003", new DateTime(2023, 3, 25), new DateTime(2023, 7, 25), 8),
                new ("Projekt D", "PROJ004", new DateTime(2023, 4, 10), new DateTime(2023, 8, 10), 4),
                new ("Projekt E", "PROJ005", new DateTime(2023, 5, 5), new DateTime(2023, 9, 5), 5),
                new ("Projekt F", "PROJ006", new DateTime(2023, 6, 15), new DateTime(2023, 10, 15), 6),
                new ("Projekt G", "PROJ007", new DateTime(2023, 7, 25), new DateTime(2023, 11, 25), 4),
                new ("Projekt H", "PROJ008", new DateTime(2023, 8, 30), new DateTime(2023, 12, 30), 8),
                new ("Projekt I", "PROJ009", new DateTime(2023, 9, 20), new DateTime(2024, 1, 20), 6),
                new ("Projekt J", "PROJ010", new DateTime(2023, 10, 15), new DateTime(2024, 2, 15), 6)
            };
            context.Projects.AddRange(projects);
            context.SaveChanges();

            var participantTypes = new ParticipantType[]
            {
                new ("Opiekun", "Opiekun projektu"),
                new ("Kierownik", "Kierownik projektu"),
                new ("Student", "Student"),
                new ("Klient", "Klient")
            };
            context.ParticipantTypes.AddRange(participantTypes);
            context.SaveChanges();

            var participants = new Participant[]
            {
                new ("Artur", "Wilczak", "s94089@student.pg.edu.pl", 3, null, null, null),
                new ("Jan", "Kowalski", "jan.kowalski@example.com", 1, null, null, null),
                new ("Anna", "Nowak", "anna.nowak@example.com", 2, null, null, null),
                new ("Piotr", "Wiśniewski", "piotr.wisniewski@example.com", 1, null, null, null),
                new ("Katarzyna", "Wójcik", "katarzyna.wojcik@example.com", 2, null, null, null),
                new ("Tomasz", "Kowalczyk", "tomasz.kowalczyk@example.com", 1, null, null, null),
                new ("Agnieszka", "Zielińska", "agnieszka.zielinska@example.com", 2, null, null, null),
                new ("Marek", "Szymański", "marek.szymanski@example.com", 1, null, null, null),
                new ("Magdalena", "Lewandowska", "magdalena.lewandowska@example.com", 2, null, null, null),
                new ("Paweł", "Kamiński", "pawel.kaminski@example.com", 1, null, null, null)
            };
            context.Participants.AddRange(participants);
            context.SaveChanges();

            var teamParticipants = new TeamParticipants[]
            {
                new (1, 1),
                new (2, 2),
                new (2, 3),
                new (4, 4),
                new (4, 5),
                new (4, 6),
                new (1, 7),
                new (3, 8),
                new (1, 9),
                new (2, 10),
                new (3, 2)
            };
            context.TeamParticipants.AddRange(teamParticipants);
            context.SaveChanges();

            // Document(string name, string? description, int authorId, int? teamId, int? teamLeaderId, int? projectId,
            // DateTime createDate, DateTime updateDate, int versionId, string? fileName)
            var documents = new Document[]
            {
                new ("Specyfikacja wymagań", "Dokument zawierający specyfikację wymagań systemowych.", 1, 1, 1, 2, DateTime.Parse("2023-01-10"), DateTime.Parse("2023-01-20"), 1, "specyfikacja_wymagan.pdf"),
                new ("Analiza systemu", "Dokument zawierający analizę systemu.", 10, 1, 2, 1, DateTime.Parse("2023-02-15"), DateTime.Parse("2023-02-25"), 1, "analiza_systemu.pdf"),
                new ("Projekt architektury", null, 103, 2, 3, 1, DateTime.Parse("2023-03-01"), DateTime.Parse("2023-03-10"), 1, "projekt_architektury.pdf"),
                new ("Testowanie", "Dokument zawierający plan testowania.", 4, 3, 4, 1, DateTime.Parse("2023-04-05"), DateTime.Parse("2023-04-15"), 2, "plan_testowania.pdf"),
                new ("Podręcznik użytkownika",null, 5, 4, 5, 1, DateTime.Parse("2023-05-10"), DateTime.Parse("2023-05-20"), 3, "podrecznik_uzytkownika.pdf"),
                new ("Plan wdrożenia", "Dokument zawierający plan wdrożenia.", 7, null, null, null, DateTime.Parse("2023-06-01"), DateTime.Parse("2023-06-10"), 1, "plan_wdrozenia.pdf"),
                new ("Opis systemu", "Dokument zawierający opis systemu.", 7, 2, 6, 1, DateTime.Parse("2023-07-10"), DateTime.Parse("2023-07-20"), 1, "opis_systemu.pdf"),
                new ("Raport wydajności",null, 8, 1, 207, 1, DateTime.Parse("2023-08-05"), DateTime.Parse("2023-08-15"), 1, "raport_wydajnosci.pdf"),
                new ("Dokumentacja techniczna", "Dokument zawierający dokumentację techniczną.", 109, 3, 8, 1, DateTime.Parse("2023-09-10"), DateTime.Parse("2023-09-20"), 3, "dokumentacja_techniczna.pdf"),
                new ("Analiza ryzyka", "Dokument zawierający analizę ryzyka.", 10, 2, 2, 1, DateTime.Parse("2023-10-15"), DateTime.Parse("2023-10-25"), 1, "analiza_ryzyka.pdf"),
                new ("Harmonogram",null, 1, 3, 1, 1, DateTime.Parse("2023-11-01"), DateTime.Parse("2023-11-10"), 2, "harmonogram.pdf"),
                new ("Podręcznik instalacji", "Dokument zawierający podręcznik instalacji.", 2, 3, 211, 1, DateTime.Parse("2023-12-05"), DateTime.Parse("2023-12-15"), 1, "podrecznik_instalacji.pdf"),
                new ("Specyfikacja techniczna", "Dokument zawierający specyfikację techniczną.", 3, 4, 212, 1, DateTime.Parse("2024-01-10"), DateTime.Parse("2024-01-20"), 2, "specyfikacja_techniczna.pdf"),
                new ("Raport bezpieczeństwa",null, 4, 3, 3, 1, DateTime.Parse("2024-02-15"), DateTime.Parse("2024-02-25"), 1, "raport_bezpieczenstwa.pdf"),
                new ("Dokumentacja użytkownika", "Dokument zawierający dokumentację użytkownika.", 5, 4, 4, 1, DateTime.Parse("2024-03-01"), DateTime.Parse("2024-03-10"), 1, "dokumentacja_uzytkownika.pdf"),
                new ("Opis procesu", "Dokument zawierający opis procesu.", 6, 5, null, 2, DateTime.Parse("2024-04-05"), DateTime.Parse("2024-04-15"), 1, "opis_procesu.pdf"),
                new ("Instrukcja obsługi", "Dokument zawierający instrukcję obsługi.", 7, 2, 2, 1, DateTime.Parse("2024-05-10"), DateTime.Parse("2024-05-20"), 2, "instrukcja_obslugi.pdf"),
                new ("Przewodnik wdrożeniowy",null, 8, 2, 6, 1, DateTime.Parse("2024-06-01"), DateTime.Parse("2024-06-10"), 1, "przewodnik_wdrozeniowy.pdf")
            };
            context.Documents.AddRange(documents);
            context.SaveChanges();

            var attachements = new Attachement[]
            {
                new (1, "Załącznik 1", DateTime.Parse("2023-01-10"), DateTime.Parse("2023-01-10"), [ 0x74, 0x65, 0x61, 0x6D, 0x73, 0x20, 0x74, 0x72, 0x61, 0x6E, 0x73, 0x63, 0x72, 0x69, 0x70, 0x74, 0x0D, 0x0A, 0x6D, 0x65, 0x65, 0x74, 0x69, 0x6E, 0x67, 0x20, 0x31 ], "text/plain"),
                new (1, "Załącznik 2", DateTime.Parse("2023-01-15"), DateTime.Parse("2023-01-15"), [ 0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x2c, 0x20, 0x77, 0x6f, 0x72, 0x6C, 0x64, 0x21, 0x10, 0x48, 0x6F, 0x77, 0x20, 0x61, 0x72, 0x65, 0x20, 0x79, 0x6F, 0x75, 0x3F ], "text/plain"),
                new (2, "Załącznik 3", DateTime.Parse("2023-02-20"), DateTime.Parse("2023-02-20"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (3, "Załącznik 4", DateTime.Parse("2023-03-05"), DateTime.Parse("2023-03-05"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (3, "Załącznik 5", DateTime.Parse("2023-03-10"), DateTime.Parse("2023-03-10"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (4, "Załącznik 6", DateTime.Parse("2023-04-01"), DateTime.Parse("2023-04-01"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (5, "Załącznik 7", DateTime.Parse("2023-05-15"), DateTime.Parse("2023-05-15"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (5, "Załącznik 8", DateTime.Parse("2023-05-20"), DateTime.Parse("2023-05-20"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (6, "Załącznik 9", DateTime.Parse("2023-06-05"), DateTime.Parse("2023-06-05"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (6, "Załącznik 10", DateTime.Parse("2023-06-10"), DateTime.Parse("2023-06-10"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (7, "Załącznik 11", DateTime.Parse("2023-07-01"), DateTime.Parse("2023-07-01"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (8, "Załącznik 12", DateTime.Parse("2023-08-10"), DateTime.Parse("2023-08-10"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (8, "Załącznik 13", DateTime.Parse("2023-08-15"), DateTime.Parse("2023-08-15"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (9, "Załącznik 14", DateTime.Parse("2023-09-01"), DateTime.Parse("2023-09-01"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (9, "Załącznik 15", DateTime.Parse("2023-09-05"), DateTime.Parse("2023-09-05"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (10, "Załącznik 16", DateTime.Parse("2023-10-01"), DateTime.Parse("2023-10-01"), [ 0x01, 0x02, 0x03 ], "text/plain"),
                new (10, "Załącznik 17", DateTime.Parse("2023-10-05"), DateTime.Parse("2023-10-05"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (11, "Załącznik 18", DateTime.Parse("2023-11-01"), DateTime.Parse("2023-11-01"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (12, "Załącznik 19", DateTime.Parse("2023-12-10"), DateTime.Parse("2023-12-10"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (13, "Załącznik 20", DateTime.Parse("2024-01-10"), DateTime.Parse("2024-01-10"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (13, "Załącznik 21", DateTime.Parse("2024-01-15"), DateTime.Parse("2024-01-15"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (14, "Załącznik 22", DateTime.Parse("2024-02-05"), DateTime.Parse("2024-02-05"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (15, "Załącznik 23", DateTime.Parse("2024-03-01"), DateTime.Parse("2024-03-01"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (16, "Załącznik 24", DateTime.Parse("2024-04-10"), DateTime.Parse("2024-04-10"), [ 0x61, 0x77, 0x65 ], "text/plain"),
                new (17, "Załącznik 25", DateTime.Parse("2024-05-05"), DateTime.Parse("2024-05-05"), [ 0x61, 0x77, 0x65 ], "text/plain")
            };
            context.Attachements.AddRange(attachements);
            context.SaveChanges();

            var documentHistories = new DocumentHistory[]
            {
                new (1, "Pierwsza wersja dokumentu", "1.0", "Wprowadzenie", 3, 1, DateTime.Parse("2023-01-10")),
                new (1, "Dodano nową sekcję", "1.1", "Źródła wymagań", 4, 2, DateTime.Parse("2023-01-20")),
                new (2, "Aktualizacja danych", "1.0", "Interesariusze", 4, 3, DateTime.Parse("2023-02-15")),
                new (3, "Poprawki redakcyjne", "1.0", "Cele systemu", 6, 4, DateTime.Parse("2023-03-01")),
                new (3, "Dodano nowe wymagania", "1.1", "Cele biznesowe", 6, 10, DateTime.Parse("2023-03-10")),
                new (4, "Zmiana autora", "1.0", "Użytkownicy", 8, 6, DateTime.Parse("2023-04-05")),
                new (5, "Korekta błędów", "2.0", "Systemy zewnętrzne", 8, 7, DateTime.Parse("2023-05-10")),
                new (5, "Uaktualniono dane", "2.1", "Komponenty sprzętowe", 10, 8, DateTime.Parse("2023-05-20")),
                new (6, "Nowa wersja dokumentu", "1.0", "Wymagania funkcjonalne", 10, 9, DateTime.Parse("2023-06-01")),
                new (6, "Dodano nowe wymagania", "1.1", "Wymagania na dane", 11, 10, DateTime.Parse("2023-06-10")),
                new (7, "Aktualizacja opisu", "1.1", "Wymagania jakościowe", 11, 1, DateTime.Parse("2023-07-10")),
                new (8, "Zmiana treści", "1.0", "Wymagania w zakresie wiarygodności", 12, 2, DateTime.Parse("2023-08-05")),
                new (8, "Dodano nowy rozdział", "1.1", "Wymagania w zakresie wydajności", 12, 3, DateTime.Parse("2023-08-15")),
                new (9, "Korekta merytoryczna", "2.0", "Wymagania w zakresie elastyczności", 12, 4, DateTime.Parse("2023-09-10")),
                new (9, "Poprawiono formatowanie", "2.1", "Wymagania w zakresie użyteczności", 12, 5, DateTime.Parse("2023-09-20")),
                new (1, "Aktualizacja wersji", "1.2", "Sytuacje wyjątkowe", 13, 6, DateTime.Parse("2023-10-15")),
                new (10, "Zmiana autora", "1.2", "Sytuacje nadzwyczajne", 13, 7, DateTime.Parse("2023-10-25")),
                new (11, "Dodano nową sekcję", "1.0", "Sytuacje krytyczne", 13, 8, DateTime.Parse("2023-11-01")),
                new (12, "Aktualizacja treści", "1.1", "Sytuacje awaryjne", 14, 9, DateTime.Parse("2023-12-05")),
                new (13, "Nowa wersja dokumentu", "1.2", "Wymagania sprzętowe", 14, 10, DateTime.Parse("2024-01-10")),
                new (13, "Dodano nowy rozdział", "1.3", "Wymagania programowe", 14, 10, DateTime.Parse("2024-01-20")),
                new (14, "Zmiana treści", "1.0", "Inne wymagania", 15, 2, DateTime.Parse("2024-02-15")),
                new (15, "Korekta merytoryczna", "1.1", "Kryteria akceptacyjne", 15, 3, DateTime.Parse("2024-03-01")),
                new (16, "Aktualizacja danych", "1.2", "Słownik", 15, 4, DateTime.Parse("2024-04-05")),
                new (17, "Poprawki redakcyjne", "1.0", "Załączniki", 15, 5, DateTime.Parse("2024-05-10")),
                new (18, "Nowa wersja dokumentu", "1.0", "Wprowadzenie", 3, 10, DateTime.Parse("2023-01-10")),
                new (8, "Dodano nową sekcję", "1.1", "Źródła wymagań", 4, 10, DateTime.Parse("2023-01-20")),
                new (9, "Aktualizacja danych", "1.0", "Interesariusze", 4, 3, DateTime.Parse("2023-02-15")),
                new (10, "Poprawki redakcyjne", "1.0", "Cele systemu", 6, 4, DateTime.Parse("2023-03-01")),
                new (21, "Dodano nowe wymagania", "1.1", "Cele biznesowe", 6, 5, DateTime.Parse("2023-03-10")),
                new (12, "Zmiana autora", "1.0", "Użytkownicy", 8, 6, DateTime.Parse("2023-04-05")),
                new (13, "Korekta błędów", "2.0", "Systemy zewnętrzne", 8, 7, DateTime.Parse("2023-05-10")),
                new (14, "Uaktualniono dane", "2.1", "Komponenty sprzętowe", 10, 8, DateTime.Parse("2023-05-20"))
            };
            context.DocumentHistories.AddRange(documentHistories);
            context.SaveChanges();
        }
    }
}