﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Muleki.Infra.Context;

#nullable disable

namespace Muleki.Infra.Migrations
{
    [DbContext(typeof(MulekiContext))]
    [Migration("20220510010131_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Muleki.Domain.Entities.Football", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME")
                        .HasColumnName("date");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("deleted_at");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("footballs", (string)null);
                });

            modelBuilder.Entity("Muleki.Domain.Entities.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("name");

                    b.Property<string>("Nick")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("nick");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(240)
                        .HasColumnType("VARCHAR(240)")
                        .HasColumnName("password_salt");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<sbyte>("Role")
                        .HasColumnType("TINYINT")
                        .HasColumnName("role");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("players", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Created_At = new DateTime(2022, 5, 9, 22, 1, 31, 544, DateTimeKind.Local).AddTicks(3350),
                            Email = "root@email.com",
                            Name = "Root",
                            Nick = "Root",
                            PasswordHash = "mV/+IST6+80UcjdFuaUN4CZ7mcHiClpYndmlayqk8nNYH025/PE+P/+0ulgG49fQB0ZxkH/98arOA1of40Oo7g==",
                            PasswordSalt = "gGOO/obFwf50zaJ9LhZ0fMnV8ztfLicMBcaIhEswjK+0IdNQaN0ezEmVCk/T1PTnK/6Ahz8iKmtAGjmTq/ewKPopMKLBMC0G5rAXJNeZs1db7OXoip0zL82vmKucJhNDgiKXBpy/SGxKWI81vrcCKzY+9VZIOQLnuBTrezsZPkg=",
                            Role = (sbyte)1
                        });
                });

            modelBuilder.Entity("Muleki.Domain.Entities.PlayerFootball", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("deleted_at");

                    b.Property<long>("FootballId")
                        .HasColumnType("BIGINT");

                    b.Property<long>("PlayerId")
                        .HasColumnType("BIGINT");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("FootballId");

                    b.HasIndex("PlayerId");

                    b.ToTable("player_football", (string)null);
                });

            modelBuilder.Entity("Muleki.Domain.Entities.Safebox", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("deleted_at");

                    b.Property<decimal>("Expense")
                        .HasColumnType("DECIMAL(65,30)")
                        .HasColumnName("expense");

                    b.Property<long>("FootballId")
                        .HasColumnType("BIGINT");

                    b.Property<decimal>("Income")
                        .HasColumnType("DECIMAL(65,30)")
                        .HasColumnName("income");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("FootballId")
                        .IsUnique();

                    b.ToTable("safeboxes", (string)null);
                });

            modelBuilder.Entity("Muleki.Domain.Entities.Score", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<sbyte>("Attribute")
                        .HasColumnType("TINYINT")
                        .HasColumnName("attribute");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME")
                        .HasColumnName("date");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("deleted_at");

                    b.Property<decimal>("Note")
                        .HasMaxLength(10)
                        .HasColumnType("DECIMAL(3,2)")
                        .HasColumnName("note");

                    b.Property<long>("PlayerFootballId")
                        .HasColumnType("BIGINT");

                    b.Property<short>("Quantity")
                        .HasColumnType("SMALLINT")
                        .HasColumnName("quantity");

                    b.Property<decimal>("Total")
                        .HasColumnType("DECIMAL(5,2)")
                        .HasColumnName("total");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DATETIME")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("PlayerFootballId");

                    b.ToTable("scores", (string)null);
                });

            modelBuilder.Entity("Muleki.Domain.Entities.PlayerFootball", b =>
                {
                    b.HasOne("Muleki.Domain.Entities.Football", "Football")
                        .WithMany("PlayerFootball")
                        .HasForeignKey("FootballId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Muleki.Domain.Entities.Player", "Player")
                        .WithMany("PlayerFootball")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Football");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Muleki.Domain.Entities.Safebox", b =>
                {
                    b.HasOne("Muleki.Domain.Entities.Football", "Football")
                        .WithOne()
                        .HasForeignKey("Muleki.Domain.Entities.Safebox", "FootballId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Football");
                });

            modelBuilder.Entity("Muleki.Domain.Entities.Score", b =>
                {
                    b.HasOne("Muleki.Domain.Entities.PlayerFootball", "PlayerFootball")
                        .WithMany("Scores")
                        .HasForeignKey("PlayerFootballId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerFootball");
                });

            modelBuilder.Entity("Muleki.Domain.Entities.Football", b =>
                {
                    b.Navigation("PlayerFootball");
                });

            modelBuilder.Entity("Muleki.Domain.Entities.Player", b =>
                {
                    b.Navigation("PlayerFootball");
                });

            modelBuilder.Entity("Muleki.Domain.Entities.PlayerFootball", b =>
                {
                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
