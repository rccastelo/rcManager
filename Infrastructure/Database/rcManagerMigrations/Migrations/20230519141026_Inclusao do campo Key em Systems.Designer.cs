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
    [Migration("20230519141026_Inclusao do campo Key em Systems")]
    partial class InclusaodocampoKeyemSystems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("rcManagerPermissionDomain.Entities.PermissionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pk_id_permission")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom")
                        .HasColumnName("date_from")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnName("date_to")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnName("end_time")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnName("start_time")
                        .HasColumnType("time");

                    b.Property<bool>("Status")
                        .HasColumnName("status")
                        .HasColumnType("bit");

                    b.Property<long>("System_Id")
                        .HasColumnName("fk_system_id")
                        .HasColumnType("bigint");

                    b.Property<long>("User_Id")
                        .HasColumnName("fk_user_id")
                        .HasColumnType("bigint");

                    b.Property<bool>("Weekday")
                        .HasColumnName("weekday")
                        .HasColumnType("bit");

                    b.Property<bool>("Weekend")
                        .HasColumnName("weekend")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("System_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("rcManagerSystemDomain.Entities.SystemEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pk_id_system")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnName("key")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("Status")
                        .HasColumnName("status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Systems");
                });

            modelBuilder.Entity("rcManagerUserDomain.Entities.LoginEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pk_id_login")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnName("login")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Secret")
                        .HasColumnName("secret")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<long>("User_Id")
                        .HasColumnName("fk_user_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("User_Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("rcManagerUserDomain.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pk_id_user")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("Status")
                        .HasColumnName("status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("rcManagerPermissionDomain.Entities.PermissionEntity", b =>
                {
                    b.HasOne("rcManagerSystemDomain.Entities.SystemEntity", "SystemEntity")
                        .WithMany()
                        .HasForeignKey("System_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rcManagerUserDomain.Entities.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("rcManagerUserDomain.Entities.LoginEntity", b =>
                {
                    b.HasOne("rcManagerUserDomain.Entities.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
