﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Planit.Persistence;

#nullable disable

namespace Planit.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241108212006_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Planit.Domain.Entities.CapacityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId", "Date")
                        .IsUnique();

                    b.ToTable("Capacities");
                });

            modelBuilder.Entity("Planit.Domain.Entities.ProjectAllocationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectDemandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Seniority")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProjectDemandId");

                    b.HasIndex("ResourceId");

                    b.ToTable("ProjectAllocations");
                });

            modelBuilder.Entity("Planit.Domain.Entities.ProjectDemandEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<double>("Effort")
                        .HasColumnType("float");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Seniority")
                        .HasColumnType("int");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SkillId");

                    b.ToTable("ProjectDemands");
                });

            modelBuilder.Entity("Planit.Domain.Entities.ProjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Planit.Domain.Entities.ResourceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Planit.Domain.Entities.ResourceSkillEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Seniority")
                        .HasColumnType("int");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.HasIndex("SkillId");

                    b.ToTable("ResourceSkills");
                });

            modelBuilder.Entity("Planit.Domain.Entities.SettingEntity", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Planit.Domain.Entities.SkillCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SkillCategories");
                });

            modelBuilder.Entity("Planit.Domain.Entities.SkillEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Planit.Domain.Entities.CapacityEntity", b =>
                {
                    b.HasOne("Planit.Domain.Entities.ResourceEntity", "Resource")
                        .WithMany("Capacities")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("Planit.Domain.Entities.ProjectAllocationEntity", b =>
                {
                    b.HasOne("Planit.Domain.Entities.ProjectDemandEntity", "ProjectDemand")
                        .WithMany()
                        .HasForeignKey("ProjectDemandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Planit.Domain.Entities.ResourceEntity", "Resource")
                        .WithMany("ProjectAllocations")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectDemand");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("Planit.Domain.Entities.ProjectDemandEntity", b =>
                {
                    b.HasOne("Planit.Domain.Entities.ProjectEntity", "Project")
                        .WithMany("ProjectDemands")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Planit.Domain.Entities.SkillEntity", "Skill")
                        .WithMany("ProjectDemands")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Planit.Domain.Entities.ResourceSkillEntity", b =>
                {
                    b.HasOne("Planit.Domain.Entities.ResourceEntity", "Resource")
                        .WithMany("ResourceSkills")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Planit.Domain.Entities.SkillEntity", "Skill")
                        .WithMany("ResourceSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Planit.Domain.Entities.SkillEntity", b =>
                {
                    b.HasOne("Planit.Domain.Entities.SkillCategory", "Category")
                        .WithMany("Skills")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Planit.Domain.Entities.ProjectEntity", b =>
                {
                    b.Navigation("ProjectDemands");
                });

            modelBuilder.Entity("Planit.Domain.Entities.ResourceEntity", b =>
                {
                    b.Navigation("Capacities");

                    b.Navigation("ProjectAllocations");

                    b.Navigation("ResourceSkills");
                });

            modelBuilder.Entity("Planit.Domain.Entities.SkillCategory", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Planit.Domain.Entities.SkillEntity", b =>
                {
                    b.Navigation("ProjectDemands");

                    b.Navigation("ResourceSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
