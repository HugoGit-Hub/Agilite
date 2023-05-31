namespace Agilite.Entities.Entities;

public class Sprint
{
    public int IdSprint { get; set; }

    public int FkProject { get; set; }

    public int NumberSprint { get; set; }

    public DateTime StartDateSprint { get; set; }

    public DateTime EndDateSprint { get; set; }

    public virtual Project IdProjectNavigation { get; set; } = null!;
    
    public virtual IEnumerable<SprintObjective> SprintObjectives { get; set; } = new List<SprintObjective>();
}
