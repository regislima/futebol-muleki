using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Muleki.Common.Extensions;
using Muleki.Domain.Entities;

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

        // Entity Framework Core
        public MulekiContext() { }

        public MulekiContext(DbContextOptions<MulekiContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_configuration.IsNull())
                throw new Exception("Arquivo de configuração não encontrado");
            else
            {
                switch (_configuration["Configs:Provider"])
                {
                    case "mysql":
                    case "mariadb":
                        optionsBuilder.UseMySql(
                            @"Server=172.17.0.1;Port=3306;Database=managerapi;Uid=regis;Pwd=root",
                            new MySqlServerVersion(new Version(10, 6, 4))
                        );
                        break;

                    case "sqlserver":
                        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServerConnection"));
                        break;
                    
                    default:
                        optionsBuilder.UseInMemoryDatabase(_configuration.GetConnectionString("InMemoryConnection"));
                        break;
                }
            }
    }
}