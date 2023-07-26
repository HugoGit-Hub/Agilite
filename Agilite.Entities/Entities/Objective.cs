namespace Agilite.Entities.Entities;

public class Objective
{
    public int IdObjective { get; set; }

    public int FkObjectiveType { get; set; }

    public string NameObjective { get; set; } = null!;

    public int NumberObjective { get; set; }

    public string? TextObjective { get; set; }

    public virtual ObjectiveType IdObjectiveTypeNavigation { get; set; } = null!;

    public virtual IEnumerable<SprintObjective> SprintObjectives { get; set; } = new List<SprintObjective>();

    public virtual IEnumerable<JobObjective> JobObjectives { get; set; } = new List<JobObjective>();
}
