namespace Agilite.Entities.Entities;

public class Objective
{
    public int IdObjective { get; set; }

    public int FkObjectiveType { get; set; }

    public string NameObjective { get; set; } = null!;

    public int NumberObjective { get; set; }

    public string? TextObjective { get; set; }

    public virtual ObjectiveType IdObjectiveTypeNavigation { get; set; } = null!;

    public virtual IEnumerable<Sprint> Sprints { get; set; } = new List<Sprint>();

    public virtual IEnumerable<JobObjective> JobObjectives { get; set; } = new List<JobObjective>();
}
