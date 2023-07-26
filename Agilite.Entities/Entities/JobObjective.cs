namespace Agilite.Entities.Entities;

public class JobObjective
{
    public int IdJob { get; set; }

    public int IdObjective { get; set; }

    public virtual Job IdJobNavigation { get; set; } = null!;

    public virtual Objective IdObjectiveNavigation { get; set; } = null!;
}