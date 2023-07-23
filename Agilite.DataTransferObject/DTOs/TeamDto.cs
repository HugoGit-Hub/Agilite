using Agilite.Entities.Entities;

namespace Agilite.DataTransferObject.DTOs;

public class TeamDto
{
    public int IdTeam { get; set; }

    public string NameTeam { get; set; } = null!;

    public int NumberMembersTeam { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual IEnumerable<Project> Projects { get; set; } = new List<Project>();
}