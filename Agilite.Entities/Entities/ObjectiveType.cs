namespace Agilite.Entities.Entities;

public class ObjectiveType
{
    public int IdObjectiveType { get; set; }

    public string NameObjectiveType { get; set; } = null!;

    public virtual IEnumerable<Objective> Objectives { get; set; } = new List<Objective>();
}