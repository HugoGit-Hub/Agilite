namespace Agilite.Entities.Entities;

public class SprintObjective
{
    public int IdSprint { get; set; }
    
    public int IdObjective { get; set; }

    public virtual Sprint IdSprintNavigation { get; set; } = null!;

    public virtual Objective IdObjectiveNavigation { get; set; } = null!;
}