namespace Agilite.Entities.Entities;

public class SprintObjective
{
    public int IdSprint { get; set; }
    
    public int IdObjective { get; set; }

    public Sprint IdSprintNavigation { get; set; } = null!;

    public Objective IdObjectiveNavigation { get; set; } = null!;
}