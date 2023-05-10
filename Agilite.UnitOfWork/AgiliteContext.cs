using Agilite.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Agilite.Entities.Entities.Task;

namespace Agilite.UnitOfWork;

public partial class AgiliteContext : DbContext
{
    public AgiliteContext()
    {
    }

    public AgiliteContext(DbContextOptions<AgiliteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Objective> Objectives { get; set; }

    public virtual DbSet<Planning> Plannings { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Sprint> Sprints { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamRole> TeamRoles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserMessageContact> UserMessageContacts { get; set; }

    public virtual DbSet<UserTeamTeamRole> UserTeamTeamRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder
        //    .UseCollation("utf8mb4_0900_ai_ci")
        //    .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.IdContact);

            entity.ToTable("Contact");

            entity.Property(e => e.NameContact).HasMaxLength(150);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.IdMessage);

            entity.ToTable("Message");

            entity.Property(e => e.TextMessage).HasMaxLength(3000);
        });

        modelBuilder.Entity<Objective>(entity =>
        {
            entity.HasKey(e => e.IdObjective);

            entity.ToTable("Objective");

            entity.HasIndex(e => e.SprintIdSprint, "fk_Objective_Sprint1_idx");

            entity.Property(e => e.NameObjective).HasMaxLength(150);
            entity.Property(e => e.SprintIdSprint).HasColumnName("Sprint_IdSprint");
            entity.Property(e => e.TextObjective).HasMaxLength(5000);

            entity.HasOne(d => d.SprintIdSprintNavigation).WithMany(p => p.Objectives)
                .HasForeignKey(d => d.SprintIdSprint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Objective_Sprint1");
        });

        modelBuilder.Entity<Planning>(entity =>
        {
            entity.HasKey(e => e.IdPlanning);

            entity.ToTable("Planning");

            entity.HasIndex(e => e.UserIdUser, "fk_Planning_User1_idx");

            entity.Property(e => e.IdPlanning).HasColumnName("idPlanning");
            entity.Property(e => e.EndDatePlanning).HasColumnType("datetime");
            entity.Property(e => e.StartDatePlanning).HasColumnType("datetime");
            entity.Property(e => e.UserIdUser).HasColumnName("User_IdUser");

            entity.HasOne(d => d.UserIdUserNavigation).WithMany(p => p.Plannings)
                .HasForeignKey(d => d.UserIdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Planning_User1");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.IdProject);

            entity.ToTable("Project");

            entity.HasIndex(e => e.TeamIdTeam, "fk_Project_Team1_idx");

            entity.Property(e => e.DateCreationProject).HasColumnType("datetime");
            entity.Property(e => e.DateEnded).HasMaxLength(45);
            entity.Property(e => e.NameProject).HasMaxLength(100);
            entity.Property(e => e.TeamIdTeam).HasColumnName("Team_IdTeam");

            entity.HasOne(d => d.TeamIdTeamNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.TeamIdTeam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Project_Team1");
        });

        modelBuilder.Entity<Sprint>(entity =>
        {
            entity.HasKey(e => e.IdSprint);

            entity.ToTable("Sprint");

            entity.HasIndex(e => e.ProjectIdProject, "fk_Sprint_Project1_idx");

            entity.Property(e => e.EndDateSprint).HasColumnType("datetime");
            entity.Property(e => e.ProjectIdProject).HasColumnName("Project_IdProject");
            entity.Property(e => e.StartDateSprint).HasColumnType("datetime");

            entity.HasOne(d => d.ProjectIdProjectNavigation).WithMany(p => p.Sprints)
                .HasForeignKey(d => d.ProjectIdProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Sprint_Project1");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.IdTask);

            entity.ToTable("Task");

            entity.HasIndex(e => e.ObjectiveIdObjective, "fk_Task_Objective1_idx");

            entity.Property(e => e.EndLogTimeTask).HasColumnType("datetime");
            entity.Property(e => e.NameTask).HasMaxLength(150);
            entity.Property(e => e.ObjectiveIdObjective).HasColumnName("Objective_IdObjective");
            entity.Property(e => e.StartLogTimeTask).HasColumnType("datetime");
            entity.Property(e => e.TextTask).HasMaxLength(5000);

            entity.HasOne(d => d.ObjectiveIdObjectiveNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ObjectiveIdObjective)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Task_Objective1");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.IdTeam);

            entity.ToTable("Team");

            entity.Property(e => e.NameTeam).HasMaxLength(100);
        });

        modelBuilder.Entity<TeamRole>(entity =>
        {
            entity.HasKey(e => e.IdTeamRole);

            entity.ToTable("TeamRole");

            entity.Property(e => e.IdTeamRole).HasColumnName("idTeamRole");
            entity.Property(e => e.TitleTeamRole).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.HasIndex(e => e.EmailUser, "EmailUser_UNIQUE").IsUnique();

            entity.Property(e => e.DateCreationUser).HasMaxLength(45);
            entity.Property(e => e.EmailUser).HasMaxLength(150);
            entity.Property(e => e.FirstNameUser).HasMaxLength(100);
            entity.Property(e => e.LastNameUser).HasMaxLength(100);
            entity.Property(e => e.PasswordUser).HasMaxLength(200);
        });

        modelBuilder.Entity<UserMessageContact>(entity =>
        {
            entity.HasKey(e => new { e.UserIdUser, e.ContactIdContact, e.MessageIdMessage })
                
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("UserMessageContact");

            entity.HasIndex(e => e.ContactIdContact, "fk_User_has_Contact_Contact1_idx");

            entity.HasIndex(e => e.MessageIdMessage, "fk_User_has_Contact_Message1_idx");

            entity.HasIndex(e => e.UserIdUser, "fk_User_has_Contact_User_idx");

            entity.Property(e => e.UserIdUser).HasColumnName("User_IdUser");
            entity.Property(e => e.ContactIdContact).HasColumnName("Contact_IdContact");
            entity.Property(e => e.MessageIdMessage).HasColumnName("Message_IdMessage");
            entity.Property(e => e.DateTimeUserMessageContact).HasColumnType("datetime");

            entity.HasOne(d => d.ContactIdContactNavigation).WithMany(p => p.UserMessageContacts)
                .HasForeignKey(d => d.ContactIdContact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_has_Contact_Contact1");

            entity.HasOne(d => d.MessageIdMessageNavigation).WithMany(p => p.UserMessageContacts)
                .HasForeignKey(d => d.MessageIdMessage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_has_Contact_Message1");

            entity.HasOne(d => d.UserIdUserNavigation).WithMany(p => p.UserMessageContacts)
                .HasForeignKey(d => d.UserIdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_has_Contact_User");
        });

        modelBuilder.Entity<UserTeamTeamRole>(entity =>
        {
            entity.HasKey(e => new { e.UserIdUser, e.TeamIdTeam, e.TeamRoleIdTeamRole })
                
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("UserTeamTeamRole");

            entity.HasIndex(e => e.TeamIdTeam, "fk_User_has_Team_Team1_idx");

            entity.HasIndex(e => e.TeamRoleIdTeamRole, "fk_User_has_Team_TeamRole1_idx");

            entity.HasIndex(e => e.UserIdUser, "fk_User_has_Team_User1_idx");

            entity.Property(e => e.UserIdUser).HasColumnName("User_IdUser");
            entity.Property(e => e.TeamIdTeam).HasColumnName("Team_IdTeam");
            entity.Property(e => e.TeamRoleIdTeamRole).HasColumnName("TeamRole_idTeamRole");
            entity.Property(e => e.DateTimeUserTeamTeamRole).HasColumnType("datetime");

            entity.HasOne(d => d.TeamIdTeamNavigation).WithMany(p => p.UserTeamTeamRoles)
                .HasForeignKey(d => d.TeamIdTeam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_has_Team_Team1");

            entity.HasOne(d => d.TeamRoleIdTeamRoleNavigation).WithMany(p => p.UserTeamTeamRoles)
                .HasForeignKey(d => d.TeamRoleIdTeamRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_has_Team_TeamRole1");

            entity.HasOne(d => d.UserIdUserNavigation).WithMany(p => p.UserTeamTeamRoles)
                .HasForeignKey(d => d.UserIdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_has_Team_User1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
