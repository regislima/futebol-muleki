using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muleki.Domain.Entities;

namespace Muleki.Infra.Mappings
{
    public class ScoreMap : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("scores");
            builder.HasKey(score => score.Id);

            builder.Property(score => score.Id)
                .UseMySqlIdentityColumn()
                .HasColumnName("id")
                .HasColumnType("BIGINT");

            builder.Property(score => score.Date)
                .IsRequired()
                .HasColumnName("date")
                .HasColumnType("DATETIME");
            
            builder.Property(score => score.Attribute)
                .IsRequired()
                .HasColumnName("attribute")
                .HasColumnType("TINYINT");
            
            builder.Property(score => score.Note)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("note")
                .HasColumnType("DECIMAL(3,2)");
            
            builder.Property(score => score.Quantity)
                .IsRequired()
                .HasColumnName("quantity")
                .HasColumnType("SMALLINT");

            builder.Property(score => score.Total)
                .IsRequired()
                .HasColumnName("total")
                .HasColumnType("DECIMAL(5,2)");
            
            builder.Property(score => score.Created_At)
                .IsRequired()
                .HasColumnName("created_at")
                .HasColumnType("DATETIME");

            builder.Property(score => score.Updated_At)
                .IsRequired(false)
                .HasColumnName("updated_at")
                .HasColumnType("DATETIME");
            
            builder.Property(score => score.Deleted_At)
                .IsRequired(false)
                .HasColumnName("deleted_at")
                .HasColumnType("DATETIME");
            
            builder.HasOne(score => score.PlayerFootball)
                .WithMany(playerFootball => playerFootball.Scores)
                .HasForeignKey(score => score.PlayerFootballId);
        }
    }
}