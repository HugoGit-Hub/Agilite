namespace Agilite.Entities.Entities;

public class Job
{
    public int IdJob { get; set; }

    public int FkJobSate { get; set; }

    public string NameJob { get; set; } = null!;

    public int NumberJob { get; set; }

    public string? TextJob { get; set; }

    public DateTime? StartLogTimeJob { get; set; }

    public DateTime? EndLogTimeJob { get; set; }

    public virtual JobState IdJobStateNavigation { get; set; } = null!;

    public virtual IEnumerable<Objective> Objectives { get; set; } = new List<Objective>();
}
