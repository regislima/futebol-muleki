using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muleki.Domain.Entities;

namespace Muleki.Infra.Mappings
{
    public class PlayerFootballMap : IEntityTypeConfiguration<PlayerFootball>
    {
        public void Configure(EntityTypeBuilder<PlayerFootball> builder)
        {
            builder.ToTable("player_football");
            builder.HasKey(playerFootball => playerFootball.Id);

            builder.Property(playerFootball => playerFootball.Id)
                .UseMySqlIdentityColumn()
                .HasColumnName("id")
                .HasColumnType("BIGINT");
            
            builder.Property(playerFootball => playerFootball.Created_At)
                .IsRequired()
                .HasColumnName("created_at")
                .HasColumnType("DATETIME");

            builder.Property(playerFootball => playerFootball.Updated_At)
                .IsRequired(false)
                .HasColumnName("updated_at")
                .HasColumnType("DATETIME");
            
            builder.Property(playerFootball => playerFootball.Deleted_At)
                .IsRequired(false)
                .HasColumnName("deleted_at")
                .HasColumnType("DATETIME");
            
            builder.HasOne(playerFootball => playerFootball.Player)
                .WithMany(player => player.PlayerFootball)
                .HasForeignKey(playerFootball => playerFootball.PlayerId)
                .IsRequired();
            
            builder.HasOne(playerFootball => playerFootball.Football)
                .WithMany(football => football.PlayerFootball)
                .HasForeignKey(playerFootball => playerFootball.FootballId)
                .IsRequired();
        }
    }
}