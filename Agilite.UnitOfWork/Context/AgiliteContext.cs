using Agilite.Entities.Entities;
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

    public virtual DbSet<JobObjective> JobObjectives { get; set; }

    public virtual DbSet<JobState> JobStates { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Objective> Objectives { get; set; }

    public virtual DbSet<ObjectiveType> ObjectiveTypes { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectType> ProjectTypes { get; set; }

    public virtual DbSet<Sprint> Sprints { get; set; }

    public virtual DbSet<SprintObjective> SprintObjectives { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserTeam> UserTeams { get; set; }

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

            entity.HasMany(e => e.JobObjectives)
                .WithOne(e => e.IdJobNavigation)
                .HasForeignKey(e => e.IdJob);
        });

        modelBuilder.Entity<JobObjective>(entity =>
        {
            entity.HasKey(e => e.IdObjective);

            entity.HasKey(e => e.IdJob);

            entity.HasOne(e => e.IdObjectiveNavigation)
                .WithMany(e => e.JobObjectives)
                .HasForeignKey(e => e.IdObjective);

            entity.HasOne(e => e.IdJobNavigation)
                .WithMany(e => e.JobObjectives)
                .HasForeignKey(e => e.IdJob);
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

            entity.HasMany(e => e.SprintObjectives)
                .WithOne(e => e.IdObjectiveNavigation)
                .HasForeignKey(e => e.IdObjective);

            entity.HasMany(e => e.JobObjectives)
                .WithOne(e => e.IdObjectiveNavigation)
                .HasForeignKey(e => e.IdObjective);
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

        modelBuilder.Entity<ProjectType>(entity =>
        {
            entity.HasKey(e => e.IdProjectType);

            entity.Property(e => e.NameProjectType).IsRequired();

            entity.HasMany(e => e.Projects)
                .WithOne(e => e.IdProjectTypeNavigation)
                .HasForeignKey(e => e.FkProjectType);
        });

        modelBuilder.Entity<Sprint>(entity =>
        {
            entity.HasKey(e => e.IdSprint);

            entity.ToTable("Sprint");

            entity.Property(e => e.NumberSprint);

            entity.Property(e => e.EndDateSprint).HasColumnType("datetime");

            entity.Property(e => e.StartDateSprint).HasColumnType("datetime");

            entity.HasMany(e => e.SprintObjectives)
                .WithOne(e => e.IdSprintNavigation)
                .HasForeignKey(e => e.IdSprint);
        });

        modelBuilder.Entity<SprintObjective>(entity =>
        {
            entity.HasKey(e => e.IdObjective);

            entity.HasKey(e => e.IdSprint);

            entity.HasOne(e => e.IdObjectiveNavigation)
                .WithMany(e => e.SprintObjectives)
                .HasForeignKey(e => e.IdObjective);

            entity.HasOne(e => e.IdSprintNavigation)
                .WithMany(e => e.SprintObjectives)
                .HasForeignKey(e => e.IdSprint);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.IdTeam);

            entity.ToTable("Team");

            entity.Property(e => e.NameTeam).HasMaxLength(100);

            entity.Property(e => e.NumberOfMembersTeam);

            entity.HasMany(e => e.UserTeams)
                .WithOne(e => e.IdTeamNavigation)
                .HasForeignKey(e => e.IdTeam);

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

            entity.HasMany(e => e.UserTeams)
                .WithOne(e => e.IdUserNavigation)
                .HasForeignKey(e => e.IdUser);
        });

        modelBuilder.Entity<UserTeam>(entity =>
        {
            entity.HasKey(e => new { e.IdTeam, e.IdUser });

            entity.HasOne(e => e.IdUserNavigation)
                .WithMany(e => e.UserTeams)
                .HasForeignKey(e => e.IdUser);

            entity.HasOne(e => e.IdTeamNavigation)
                .WithMany(e => e.UserTeams)
                .HasForeignKey(e => e.IdTeam);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
