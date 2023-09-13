namespace Agilite.Entities;

public class Project
{
    public int IdProject { get; set; }

    public int FkTeam { get; set; }

    public string NameProject { get; set; } = null!;

    public DateTime DateCreationProject { get; set; }

    public DateTime DateEndedProject { get; set; }

    public virtual Team IdTeamNavigation { get; set; } = null!;

    public virtual IEnumerable<Sprint> Sprints { get; set; } = new List<Sprint>();
}
