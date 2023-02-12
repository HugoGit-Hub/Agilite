namespace Agilite.Entities.Entities;

public partial class Objective
{
    public int IdObjective { get; set; }

    public int SprintIdSprint { get; set; }

    public string NameObjective { get; set; } = null!;

    public int NumberObjective { get; set; }

    public int EnumTypeObjective { get; set; }

    public string? TextObjective { get; set; }

    public virtual Sprint SprintIdSprintNavigation { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
