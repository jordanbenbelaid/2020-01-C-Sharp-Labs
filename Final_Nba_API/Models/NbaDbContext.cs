using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Nba_API.Models
{
    public class NbaDbContext : DbContext
    {
        public NbaDbContext(DbContextOptions<NbaDbContext> options) : base(options) { }
        public DbSet<NbaTeam> NbaTeams { get; set; }
        public DbSet<CurrentPlayer> CurrentPlayers { get; set; }
        public DbSet<HistoricPlayer> HistoricPlayers { get; set; }

        string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = NbaDatabase;";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //NBA Teams

            builder.Entity<NbaTeam>().HasData(

                new NbaTeam { NbaTeamID = 1, NbaTeamName = "LA Lakers", NbaTeamConference = "West", ChampionshipAppearances = 31, ChampionshipWins = 16 },
                new NbaTeam { NbaTeamID = 2, NbaTeamName = "Miami Heat", NbaTeamConference = "East", ChampionshipAppearances = 4, ChampionshipWins = 3 },
                new NbaTeam { NbaTeamID = 3, NbaTeamName = "Dallas Mavericks", NbaTeamConference = "West", ChampionshipAppearances = 2, ChampionshipWins = 1 },
                new NbaTeam { NbaTeamID = 4, NbaTeamName = "Portland Trailblazers", NbaTeamConference = "West", ChampionshipAppearances = 3, ChampionshipWins = 1 },
                new NbaTeam { NbaTeamID = 5, NbaTeamName = "Milwaukee Bucks", NbaTeamConference = "East", ChampionshipAppearances = 2, ChampionshipWins = 1 }

                );
            //Current Players

            builder.Entity<CurrentPlayer>().HasData(

                new CurrentPlayer
                {
                    CurrentPlayerID = 1,
                    CurrentPlayerName = "LeBron James",
                    CurrentPlayerPosition = "Small Forward",
                    CurrentPlayerDOB = new DateTime(1984, 12, 30),
                    NbaTeamID = 1
                },

                new CurrentPlayer
                {
                    CurrentPlayerID = 2,
                    CurrentPlayerName = "Tyler Herro",
                    CurrentPlayerPosition = "Shooting Guard",
                    CurrentPlayerDOB = new DateTime(2000, 1, 20),
                    NbaTeamID = 2
                },

                new CurrentPlayer
                {
                    CurrentPlayerID = 3, 
                    CurrentPlayerName = "Luka Doncic",
                    CurrentPlayerPosition = "Small Forward",
                    CurrentPlayerDOB = new DateTime(1999, 2, 28),
                    NbaTeamID = 3
                },

                new CurrentPlayer
                {
                    CurrentPlayerID = 4,
                    CurrentPlayerName = "Damian Lillard",
                    CurrentPlayerPosition = "Point Guard",
                    CurrentPlayerDOB = new DateTime(1990, 7, 15),
                    NbaTeamID = 4
                },

                new CurrentPlayer
                {
                    CurrentPlayerID = 5,
                    CurrentPlayerName = "Giannis Antetokounmpo",
                    CurrentPlayerPosition = "Power Forward",
                    CurrentPlayerDOB = new DateTime(1994, 12, 6),
                    NbaTeamID = 5
                }

                );
            //Historic Players

            builder.Entity<HistoricPlayer>().HasData(

                new HistoricPlayer
                {
                    HistoricPlayerID = 1,
                    HistoricPlayerName = "Jerry West",
                    HistoricPlayerPosition = "Point Guard",
                    HistoricPlayerDOB = new DateTime(1938,5,28),
                    NbaTeamID = 1,
                    PlayerRetired = new DateTime(1974,1,1)
                },

                new HistoricPlayer
                {
                    HistoricPlayerID = 2,
                    HistoricPlayerName = "Dwayne Wade",
                    HistoricPlayerPosition = "Shooting Guard",
                    HistoricPlayerDOB = new DateTime(1982, 1, 17),
                    NbaTeamID = 2,
                    PlayerRetired = new DateTime(2019,1,1)
                },

                new HistoricPlayer
                {
                    HistoricPlayerID = 3,
                    HistoricPlayerName = "Dirk Nowitzki",
                    HistoricPlayerPosition = "Centre",
                    HistoricPlayerDOB = new DateTime(1978, 6, 19),
                    NbaTeamID = 3,
                    PlayerRetired = new DateTime(2019,1,1)
                },

                new HistoricPlayer
                {
                    HistoricPlayerID = 4,
                    HistoricPlayerName = "Clyde Drexler",
                    HistoricPlayerPosition = "Small Forward",
                    HistoricPlayerDOB = new DateTime(1962, 6, 22),
                    NbaTeamID = 4,
                    PlayerRetired = new DateTime(1998,1,1)
                },

                new HistoricPlayer
                {
                    HistoricPlayerID = 5,
                    HistoricPlayerName = "Karim Abdul-Jabbar",
                    HistoricPlayerPosition = "Centre",
                    HistoricPlayerDOB = new DateTime(1947, 4, 16),
                    NbaTeamID = 5,
                    PlayerRetired = new DateTime(1989,1,1)
                }

                );

            builder.Entity<NbaTeam>()
                .Property(c => c.NbaTeamName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<CurrentPlayer>()
                .HasOne(c => c.NbaTeam);

        }
    }
}