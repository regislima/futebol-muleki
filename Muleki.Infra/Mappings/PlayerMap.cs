using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muleki.Domain.Entities;

namespace Muleki.Infra.Mappings
{
    public class PlayerMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("players");
            builder.HasKey(player => player.Id);

            builder.Property(player => player.Id)
                .UseMySqlIdentityColumn()
                .HasColumnType("INT");
            
            builder.Property(player => player.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name")
                .HasColumnType("VARCHAR");
            
            builder.Property(player => player.Nick)
                .HasMaxLength(50)
                .HasColumnName("nick")
                .HasColumnType("VARCHAR");

            builder.Property(player => player.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email")
                .HasColumnType("VARCHAR");
            
            builder.Property(player => player.Password)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("password")
                .HasColumnType("VARCHAR");
            
            builder.Property(player => player.Role)
                .IsRequired()
                .HasColumnName("role")
                .HasColumnType("TINYINT");
            
            builder.Property(player => player.Created_At)
                .IsRequired()
                .HasColumnName("created_at")
                .HasColumnType("DATETIME");

            builder.Property(player => player.Updated_At)
                .IsRequired(false)
                .HasColumnName("updated_at")
                .HasColumnType("DATETIME");
            
            builder.Property(player => player.Deleted_At)
                .IsRequired(false)
                .HasColumnName("deleted_at")
                .HasColumnType("DATETIME");

            builder.HasData
            (
                // Usuário root - Senha: 123456789
                new Player(1, "Root", "Root", "root@email.com", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", Role.ADMINISTRATOR)
            );
        }
    }
}