﻿// <auto-generated />
using System;
using Agilite.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Agilite.UnitOfWork.Migrations
{
    [DbContext(typeof(AgiliteDesignContext))]
    partial class AgiliteDesignContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Agilite.Entities.Entities.Job", b =>
                {
                    b.Property<int>("IdJob")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJob"));

                    b.Property<DateTime?>("EndLogTimeJob")
                        .HasColumnType("datetime");

                    b.Property<int>("FkJobSate")
                        .HasColumnType("int");

                    b.Property<string>("NameJob")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("NumberJob")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartLogTimeJob")
                        .HasColumnType("datetime");

                    b.Property<string>("TextJob")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJob");

                    b.HasIndex("FkJobSate");

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("Agilite.Entities.Entities.JobObjective", b =>
                {
                    b.Property<int>("IdJob")
                        .HasColumnType("int");

                    b.Property<int>("IdObjective")
                        .HasColumnType("int");

                    b.HasKey("IdJob");

                    b.HasIndex("IdObjective");

                    b.ToTable("JobObjectives");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.JobState", b =>
                {
                    b.Property<int>("IdJobState")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJobState"));

                    b.Property<string>("NameJobState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJobState");

                    b.ToTable("JobState", (string)null);
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Message", b =>
                {
                    b.Property<int>("IdMessage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMessage"));

                    b.Property<bool>("ArchivedMessage")
                        .HasColumnType("bit");

                    b.Property<int>("FkReceiverUser")
                        .HasColumnType("int");

                    b.Property<int>("FkSenderUser")
                        .HasColumnType("int");

                    b.Property<string>("TextMessage")
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.HasKey("IdMessage");

                    b.HasIndex("FkSenderUser");

                    b.ToTable("Message", (string)null);
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Objective", b =>
                {
                    b.Property<int>("IdObjective")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdObjective"));

                    b.Property<int>("FkObjectiveType")
                        .HasColumnType("int");

                    b.Property<string>("NameObjective")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("NumberObjective")
                        .HasColumnType("int");

                    b.Property<string>("TextObjective")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdObjective");

                    b.HasIndex("FkObjectiveType");

                    b.ToTable("Objective", (string)null);
                });

            modelBuilder.Entity("Agilite.Entities.Entities.ObjectiveType", b =>
                {
                    b.Property<int>("IdObjectiveType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdObjectiveType"));

                    b.Property<string>("NameObjectiveType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdObjectiveType");

                    b.ToTable("ObjectiveTypes");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Project", b =>
                {
                    b.Property<int>("IdProject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProject"));

                    b.Property<DateTime>("DateCreationProject")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateEndedProject")
                        .HasColumnType("datetime");

                    b.Property<int>("FkProjectType")
                        .HasColumnType("int");

                    b.Property<int>("FkTeam")
                        .HasColumnType("int");

                    b.Property<string>("NameProject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdProject");

                    b.HasIndex("FkProjectType");

                    b.HasIndex("FkTeam");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("Agilite.Entities.Entities.ProjectType", b =>
                {
                    b.Property<int>("IdProjectType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProjectType"));

                    b.Property<string>("NameProjectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProjectType");

                    b.ToTable("ProjectTypes");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Sprint", b =>
                {
                    b.Property<int>("IdSprint")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSprint"));

                    b.Property<DateTime>("EndDateSprint")
                        .HasColumnType("datetime");

                    b.Property<int>("FkProject")
                        .HasColumnType("int");

                    b.Property<int>("NumberSprint")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateSprint")
                        .HasColumnType("datetime");

                    b.HasKey("IdSprint");

                    b.HasIndex("FkProject");

                    b.ToTable("Sprint", (string)null);
                });

            modelBuilder.Entity("Agilite.Entities.Entities.SprintObjective", b =>
                {
                    b.Property<int>("IdSprint")
                        .HasColumnType("int");

                    b.Property<int>("IdObjective")
                        .HasColumnType("int");

                    b.HasKey("IdSprint");

                    b.HasIndex("IdObjective");

                    b.ToTable("SprintObjectives");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Team", b =>
                {
                    b.Property<int>("IdTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTeam"));

                    b.Property<string>("NameTeam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberOfMembersTeam")
                        .HasColumnType("int");

                    b.HasKey("IdTeam");

                    b.ToTable("Team", (string)null);
                });

            modelBuilder.Entity("Agilite.Entities.Entities.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<int>("AgeUser")
                        .HasColumnType("int");

                    b.Property<bool>("ArchivedUser")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreationUser")
                        .HasColumnType("datetime");

                    b.Property<string>("EmailUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstNameUser")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastNameUser")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordUser")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte[]>("SaltUser")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("IdUser");

                    b.HasIndex("EmailUser")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Agilite.Entities.Entities.UserTeam", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdTeam")
                        .HasColumnType("int");

                    b.Property<string>("RoleUserTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.HasIndex("IdTeam");

                    b.ToTable("UserTeams");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Job", b =>
                {
                    b.HasOne("Agilite.Entities.Entities.JobState", "IdJobStateNavigation")
                        .WithMany("Jobs")
                        .HasForeignKey("FkJobSate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdJobStateNavigation");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.JobObjective", b =>
                {
                    b.HasOne("Agilite.Entities.Entities.Job", "IdJobNavigation")
                        .WithMany("JobObjectives")
                        .HasForeignKey("IdJob")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agilite.Entities.Entities.Objective", "IdObjectiveNavigation")
                        .WithMany("JobObjectives")
                        .HasForeignKey("IdObjective")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdJobNavigation");

                    b.Navigation("IdObjectiveNavigation");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Message", b =>
                {
                    b.HasOne("Agilite.Entities.Entities.User", "IdUserNavigation")
                        .WithMany("Messages")
                        .HasForeignKey("FkSenderUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Objective", b =>
                {
                    b.HasOne("Agilite.Entities.Entities.ObjectiveType", "IdObjectiveTypeNavigation")
                        .WithMany("Objectives")
                        .HasForeignKey("FkObjectiveType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdObjectiveTypeNavigation");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Project", b =>
                {
                    b.HasOne("Agilite.Entities.Entities.ProjectType", "IdProjectTypeNavigation")
                        .WithMany("Projects")
                        .HasForeignKey("FkProjectType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agilite.Entities.Entities.Team", "IdTeamNavigation")
                        .WithMany("Projects")
                        .HasForeignKey("FkTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdProjectTypeNavigation");

                    b.Navigation("IdTeamNavigation");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Sprint", b =>
                {
                    b.HasOne("Agilite.Entities.Entities.Project", "IdProjectNavigation")
                        .WithMany("Sprints")
                        .HasForeignKey("FkProject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdProjectNavigation");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.SprintObjective", b =>
                {
                    b.HasOne("Agilite.Entities.Entities.Objective", "IdObjectiveNavigation")
                        .WithMany("SprintObjectives")
                        .HasForeignKey("IdObjective")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agilite.Entities.Entities.Sprint", "IdSprintNavigation")
                        .WithMany("SprintObjectives")
                        .HasForeignKey("IdSprint")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdObjectiveNavigation");

                    b.Navigation("IdSprintNavigation");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.UserTeam", b =>
                {
                    b.HasOne("Agilite.Entities.Entities.Team", "IdTeamNavigation")
                        .WithMany("UserTeams")
                        .HasForeignKey("IdTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agilite.Entities.Entities.User", "IdUserNavigation")
                        .WithMany("UserTeams")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdTeamNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Job", b =>
                {
                    b.Navigation("JobObjectives");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.JobState", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Objective", b =>
                {
                    b.Navigation("JobObjectives");

                    b.Navigation("SprintObjectives");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.ObjectiveType", b =>
                {
                    b.Navigation("Objectives");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Project", b =>
                {
                    b.Navigation("Sprints");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.ProjectType", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Sprint", b =>
                {
                    b.Navigation("SprintObjectives");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.Team", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("UserTeams");
                });

            modelBuilder.Entity("Agilite.Entities.Entities.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("UserTeams");
                });
#pragma warning restore 612, 618
        }
    }
}
