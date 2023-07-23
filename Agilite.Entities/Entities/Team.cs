namespace Agilite.Entities.Entities;

public class Team
{
    public int IdTeam { get; set; }

    public string NameTeam { get; set; } = null!;

    public int NumberOfMembersTeam { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual IEnumerable<Project> Projects { get; set; } = new List<Project>();
}
