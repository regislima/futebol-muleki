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
                .HasColumnName("id")
                .HasColumnType("BIGINT");
            
            builder.Property(player => player.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name")
                .HasColumnType("VARCHAR");
            
            builder.Property(player => player.Nick)
                .IsRequired(false)
                .HasMaxLength(50)
                .HasColumnName("nick")
                .HasColumnType("VARCHAR");

            builder.Property(player => player.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email")
                .HasColumnType("VARCHAR");
            
            builder.Property(player => player.PasswordHash)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("password_hash")
                .HasColumnType("VARCHAR");

            builder.Property(player => player.PasswordHash)
                .IsRequired()
                .HasMaxLength(240)
                .HasColumnName("password_salt")
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
                new Player
                (
                    1, "Root", "Root", "root@email.com",
                    "mV/+IST6+80UcjdFuaUN4CZ7mcHiClpYndmlayqk8nNYH025/PE+P/+0ulgG49fQB0ZxkH/98arOA1of40Oo7g==",
                    "gGOO/obFwf50zaJ9LhZ0fMnV8ztfLicMBcaIhEswjK+0IdNQaN0ezEmVCk/T1PTnK/6Ahz8iKmtAGjmTq/ewKPopMKLBMC0G5rAXJNeZs1db7OXoip0zL82vmKucJhNDgiKXBpy/SGxKWI81vrcCKzY+9VZIOQLnuBTrezsZPkg=",
                    Role.ADMINISTRATOR
                )
            );
        }
    }
}