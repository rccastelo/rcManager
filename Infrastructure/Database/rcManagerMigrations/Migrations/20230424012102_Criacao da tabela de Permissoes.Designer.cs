﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rcManagerMigrations;

namespace rcManagerMigrations.Migrations
{
    [DbContext(typeof(MigrationsDbContext))]
    [Migration("20230424012102_Criacao da tabela de Permissoes")]
    partial class CriacaodatabeladePermissoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("rcManagerEntities.Entities.PermissionEntity", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date_from")
                        .HasColumnName("date_from")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_to")
                        .HasColumnName("date_to")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("end_time")
                        .HasColumnName("end_time")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("start_time")
                        .HasColumnName("start_time")
                        .HasColumnType("time");

                    b.Property<bool>("status")
                        .HasColumnName("status")
                        .HasColumnType("bit");

                    b.Property<long>("system_id")
                        .HasColumnName("system_id")
                        .HasColumnType("bigint");

                    b.Property<long>("user_id")
                        .HasColumnName("user_id")
                        .HasColumnType("bigint");

                    b.Property<bool>("weekday")
                        .HasColumnName("weekday")
                        .HasColumnType("bit");

                    b.Property<bool>("weekend")
                        .HasColumnName("weekend")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("rcManagerEntities.Entities.SystemEntity", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("status")
                        .HasColumnName("status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Systems");
                });

            modelBuilder.Entity("rcManagerEntities.Entities.UserEntity", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("status")
                        .HasColumnName("status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}