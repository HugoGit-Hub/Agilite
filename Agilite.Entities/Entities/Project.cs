namespace Agilite.Entities.Entities;

public partial class Project
{
    public int IdProject { get; set; }

    public int TeamIdTeam { get; set; }

    public string NameProject { get; set; } = null!;

    public DateTime DateCreationProject { get; set; }

    public string? DateEnded { get; set; }

    public virtual ICollection<Sprint> Sprints { get; } = new List<Sprint>();

    public virtual Team TeamIdTeamNavigation { get; set; } = null!;
}
