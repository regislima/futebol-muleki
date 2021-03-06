using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Muleki.Domain.Entities;
using Muleki.Infra.Mappings;

namespace Muleki.Infra.Context
{
    public class MulekiContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Football> Footballs { get; set; }
        public DbSet<Safebox> SafeBoxes { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<PlayerFootball> PlayersFootballs { get; set; }
        private readonly IConfiguration _configuration;

        // Empty constructor for add migrations
        public MulekiContext() { }

        public MulekiContext(DbContextOptions<MulekiContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PlayerMap());
            builder.ApplyConfiguration(new FootballMap());
            builder.ApplyConfiguration(new SafeboxMap());
            builder.ApplyConfiguration(new ScoreMap());
            builder.ApplyConfiguration(new PlayerFootballMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /* Development (use to apply migrations)
            optionsBuilder.UseMySql(
                @"Server=127.0.0.1;Port=3306;Database=mulekiapi;Uid=root;Pwd=root",
                new MySqlServerVersion(new Version(10, 6, 5))
            );
            */

            // Production
            optionsBuilder.UseMySql(
                _configuration.GetConnectionString("MySqlConnection"),
                new MySqlServerVersion(new Version(10, 6, 5))
            );
        }
    }
}