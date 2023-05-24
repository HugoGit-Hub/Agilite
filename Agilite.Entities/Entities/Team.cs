namespace Agilite.Entities.Entities;

public class Team
{
    public int IdTeam { get; set; }

    public string NameTeam { get; set; } = null!;

    public int NumberOfMembersTeam { get; set; }

    public virtual IEnumerable<UserTeam> UserTeams { get; set; } = new List<UserTeam>();

    public virtual IEnumerable<Project> Projects { get; set; } = new List<Project>();
}
