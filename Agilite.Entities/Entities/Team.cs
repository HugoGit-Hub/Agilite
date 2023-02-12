namespace Agilite.Entities.Entities;

public partial class Team
{
    public int IdTeam { get; set; }

    public string NameTeam { get; set; } = null!;

    public int NumberMembersTeam { get; set; }

    public virtual ICollection<Project> Projects { get; } = new List<Project>();

    public virtual ICollection<UserTeamTeamRole> UserTeamTeamRoles { get; } = new List<UserTeamTeamRole>();
}
