namespace Agilite.Entities.Entities;

public class ProjectType
{
    public int IdProjectType { get; set; }

    public string NameProjectType { get; set; } = null!;

    public virtual IEnumerable<Project> Projects { get; set; } = new List<Project>();
}