namespace Agilite.Entities.Entities;

public class JobObjective
{
    public int IdJob { get; set; }

    public int IdObjective { get; set; }

    public Job IdJobNavigation { get; set; } = null!;

    public Objective IdObjectiveNavigation { get; set; } = null!;
}