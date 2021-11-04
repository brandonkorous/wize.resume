﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wize.resume.data.V1;

namespace wize.resume.data.Migrations
{
    [DbContext(typeof(WizeContext))]
    partial class WizeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("wize.resume.data.V1.Models.Award", b =>
                {
                    b.Property<int>("AwardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("Awarded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Nominated")
                        .HasColumnType("datetime2");

                    b.Property<string>("NominatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Summary")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AwardId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EducationId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExperienceId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.ExperienceItem", b =>
                {
                    b.Property<int>("ExperienceItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentExperienceItemId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExperienceItemId");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("ParentExperienceItemId");

                    b.ToTable("ExperienceItems");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.ExperienceTag", b =>
                {
                    b.Property<int>("ExperienceTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExperienceTagId");

                    b.HasIndex("TagId");

                    b.HasIndex("ExperienceId", "TagId")
                        .IsUnique()
                        .HasDatabaseName("Unique_Key_Relations");

                    b.ToTable("ExperienceTags");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Expertise", b =>
                {
                    b.Property<int>("ExpertiseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExpertiseId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Expertises");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Resume", b =>
                {
                    b.Property<Guid>("ResumeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccentColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccentTextColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AwardsTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("DateFormat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExperienceTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpertiseTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Footnote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FootnoteTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SafeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SummaryTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Template")
                        .HasColumnType("int");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ResumeId");

                    b.HasIndex("SafeName")
                        .HasDatabaseName("UniqueKey_SafeName");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TagId");

                    b.HasIndex("Title")
                        .HasDatabaseName("UniqueKey_Title");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Volunteer", b =>
                {
                    b.Property<int>("VolunteerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VolunteerId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Award", b =>
                {
                    b.HasOne("wize.resume.data.V1.Models.Resume", "Resume")
                        .WithMany("Awards")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Education", b =>
                {
                    b.HasOne("wize.resume.data.V1.Models.Resume", "Resume")
                        .WithMany("Education")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Experience", b =>
                {
                    b.HasOne("wize.resume.data.V1.Models.Resume", "Resume")
                        .WithMany("Experiences")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.ExperienceItem", b =>
                {
                    b.HasOne("wize.resume.data.V1.Models.Experience", "Experience")
                        .WithMany("Items")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wize.resume.data.V1.Models.ExperienceItem", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentExperienceItemId");

                    b.Navigation("Experience");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.ExperienceTag", b =>
                {
                    b.HasOne("wize.resume.data.V1.Models.Experience", "Experience")
                        .WithMany("TagLinks")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wize.resume.data.V1.Models.Tag", "Tag")
                        .WithMany("ExperienceLinks")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experience");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Expertise", b =>
                {
                    b.HasOne("wize.resume.data.V1.Models.Resume", "Resume")
                        .WithMany()
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Project", b =>
                {
                    b.HasOne("wize.resume.data.V1.Models.Experience", "Experience")
                        .WithMany()
                        .HasForeignKey("ExperienceId");

                    b.HasOne("wize.resume.data.V1.Models.Resume", "Resume")
                        .WithMany()
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experience");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Volunteer", b =>
                {
                    b.HasOne("wize.resume.data.V1.Models.Resume", "Resume")
                        .WithMany()
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Experience", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("TagLinks");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.ExperienceItem", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Resume", b =>
                {
                    b.Navigation("Awards");

                    b.Navigation("Education");

                    b.Navigation("Experiences");
                });

            modelBuilder.Entity("wize.resume.data.V1.Models.Tag", b =>
                {
                    b.Navigation("ExperienceLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
