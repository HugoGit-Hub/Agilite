﻿using Agilite.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agilite.UnitOfWork.Context;

public partial class AgiliteContext : DbContext
{
    public AgiliteContext()
    {
    }

    public AgiliteContext(DbContextOptions<AgiliteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobState> JobStates { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Objective> Objectives { get; set; }

    public virtual DbSet<ObjectiveType> ObjectiveTypes { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Sprint> Sprints { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.IdJob);

            entity.ToTable("Job");

            entity.Property(e => e.NameJob)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(e => e.NumberJob);

            entity.Property(e => e.TextJob).HasMaxLength(5000);

            entity.Property(e => e.EndLogTimeJob).HasColumnType("datetime");

            entity.Property(e => e.StartLogTimeJob).HasColumnType("datetime");

            entity.HasMany(e => e.Objectives)
                .WithMany(e => e.Jobs);
        });

        modelBuilder.Entity<JobState>(entity =>
        {
            entity.HasKey(e => e.IdJobState);

            entity.ToTable("JobState");

            entity.Property(e => e.NameJobState).IsRequired();

            entity.HasMany(e => e.Jobs)
                .WithOne(e => e.IdJobStateNavigation)
                .HasForeignKey(e => e.FkJobSate);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.IdMessage);

            entity.ToTable("Message");

            entity.Property(e => e.TextMessage).HasMaxLength(3000);

            entity.Property(e => e.ArchivedMessage).IsRequired();

            entity.HasOne(e => e.IdUserNavigation)
                .WithMany(e => e.Messages)
                .HasForeignKey(e => e.FkSenderUser);
        });

        modelBuilder.Entity<Objective>(entity =>
        {
            entity.HasKey(e => e.IdObjective);

            entity.ToTable("Objective");

            entity.Property(e => e.NameObjective)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(e => e.NumberObjective);

            entity.Property(e => e.TextObjective).HasMaxLength(5000);

            entity.HasMany(e => e.Sprints)
                .WithMany(e => e.Objectives);

            entity.HasMany(e => e.Jobs)
                .WithMany(e => e.Objectives);
        });

        modelBuilder.Entity<ObjectiveType>(entity =>
        {
            entity.HasKey(e => e.IdObjectiveType);

            entity.Property(e => e.NameObjectiveType).IsRequired();

            entity.HasMany(e => e.Objectives)
                .WithOne(e => e.IdObjectiveTypeNavigation)
                .HasForeignKey(e => e.FkObjectiveType);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.IdProject);

            entity.ToTable("Project");

            entity.Property(e => e.NameProject).HasMaxLength(100);

            entity.Property(e => e.DateCreationProject).HasColumnType("datetime");

            entity.Property(e => e.DateEndedProject).HasColumnType("datetime");

            entity.HasMany(e => e.Sprints)
                .WithOne(e => e.IdProjectNavigation)
                .HasForeignKey(e => e.FkProject);
        });

        modelBuilder.Entity<Sprint>(entity =>
        {
            entity.HasKey(e => e.IdSprint);

            entity.ToTable("Sprint");

            entity.Property(e => e.NumberSprint);

            entity.Property(e => e.EndDateSprint).HasColumnType("datetime");

            entity.Property(e => e.StartDateSprint).HasColumnType("datetime");

            entity.HasMany(e => e.Objectives)
                .WithMany(e => e.Sprints);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.IdTeam);

            entity.ToTable("Team");

            entity.Property(e => e.NameTeam).HasMaxLength(100);

            entity.Property(e => e.NumberOfMembersTeam);

            entity.HasMany(e => e.Users)
                .WithMany(e => e.Teams);

            entity.HasMany(e => e.Projects)
                .WithOne(e => e.IdTeamNavigation)
                .HasForeignKey(e => e.FkTeam);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.FirstNameUser)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.LastNameUser)
                .HasMaxLength(100)
                .IsRequired();

            entity.HasIndex(e => e.EmailUser)
                .IsUnique();

            entity.Property(e => e.PasswordUser)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(e => e.SaltUser)
                .IsRequired();

            entity.Property(e => e.DateCreationUser).HasColumnType("datetime");

            entity.Property(e => e.AgeUser);

            entity.Property(e => e.ArchivedUser);

            entity.HasMany(e => e.Messages)
                .WithOne(e => e.IdUserNavigation)
                .HasForeignKey(e => e.FkSenderUser);

            entity.HasMany(e => e.Teams)
                .WithMany(e => e.Users);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
