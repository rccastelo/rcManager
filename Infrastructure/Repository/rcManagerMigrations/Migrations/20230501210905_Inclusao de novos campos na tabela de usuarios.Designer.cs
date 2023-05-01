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
    [Migration("20230501210905_Inclusao de novos campos na tabela de usuarios")]
    partial class Inclusaodenovoscamposnatabeladeusuarios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("rcManagerPermissionDomain.PermissionEntity", b =>
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

                    b.HasIndex("system_id");

                    b.HasIndex("user_id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("rcManagerSystemDomain.SystemEntity", b =>
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

            modelBuilder.Entity("rcManagerUserDomain.UserEntity", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnName("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnName("login")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("name")
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("status")
                        .HasColumnName("status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnName("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("rcManagerPermissionDomain.PermissionEntity", b =>
                {
                    b.HasOne("rcManagerSystemDomain.SystemEntity", "SystemEntity")
                        .WithMany()
                        .HasForeignKey("system_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rcManagerUserDomain.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}