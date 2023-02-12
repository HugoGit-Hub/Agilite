namespace Agilite.Entities.Entities;

public partial class Sprint
{
    public int IdSprint { get; set; }

    public int ProjectIdProject { get; set; }

    public int NumberSprint { get; set; }

    public DateTime StartDateSprint { get; set; }

    public DateTime EndDateSprint { get; set; }

    public virtual ICollection<Objective> Objectives { get; } = new List<Objective>();

    public virtual Project ProjectIdProjectNavigation { get; set; } = null!;
}
