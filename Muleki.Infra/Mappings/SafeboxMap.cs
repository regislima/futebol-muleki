using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muleki.Domain.Entities;

namespace Muleki.Infra.Mappings
{
    public class SafeboxMap : IEntityTypeConfiguration<Safebox>
    {
        public void Configure(EntityTypeBuilder<Safebox> builder)
        {
            builder.ToTable("safeboxes");
            builder.HasKey(safebox => safebox.Id);

            builder.Property(safebox => safebox.Id)
                .UseMySqlIdentityColumn()
                .HasColumnName("id")
                .HasColumnType("BIGINT");
            
            builder.Property(safebox => safebox.IncomeValue)
                .IsRequired()
                .HasColumnName("income")
                .HasColumnType("DECIMAL(5,2)");

            builder.Property(safebox => safebox.ExpenseValue)
                .IsRequired()
                .HasColumnName("expense")
                .HasColumnType("DECIMAL(5,2)");

            builder.Property(safebox => safebox.Created_At)
                .IsRequired()
                .HasColumnName("created_at")
                .HasColumnType("DATETIME");

            builder.Property(safebox => safebox.Updated_At)
                .IsRequired(false)
                .HasColumnName("updated_at")
                .HasColumnType("DATETIME");
            
            builder.Property(safebox => safebox.Deleted_At)
                .IsRequired(false)
                .HasColumnName("deleted_at")
                .HasColumnType("DATETIME");
            
            builder.HasOne(safebox => safebox.Football)
                .WithOne()
                .HasForeignKey<Safebox>(safebox => safebox.FootballId)
                .IsRequired();
        }
    }
}