using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muleki.Domain.Entities;

namespace Muleki.Infra.Mappings
{
    public class FootballMap : IEntityTypeConfiguration<Football>
    {
        public void Configure(EntityTypeBuilder<Football> builder)
        {
            builder.ToTable("footballs");
            builder.HasKey(football => football.Id);

            builder.Property(football => football.Id)
                .UseMySqlIdentityColumn()
                .HasColumnName("id")
                .HasColumnType("BIGINT");
            
            builder.Property(football => football.Created_At)
                .IsRequired()
                .HasColumnName("created_at")
                .HasColumnType("DATETIME");

            builder.Property(football => football.Updated_At)
                .IsRequired(false)
                .HasColumnName("updated_at")
                .HasColumnType("DATETIME");
            
            builder.Property(football => football.Deleted_At)
                .IsRequired(false)
                .HasColumnName("deleted_at")
                .HasColumnType("DATETIME");
        }
    }
}