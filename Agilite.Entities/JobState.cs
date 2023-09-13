namespace Agilite.Entities;

public class JobState
{
    public int IdJobState { get; set; }

    public string NameJobState { get; set; } = null!;

    public virtual IEnumerable<Job> Jobs { get; set; } = new List<Job>();
}