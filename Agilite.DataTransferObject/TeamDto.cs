namespace Agilite.DataTransferObject;

public class TeamDto
{
    public int IdTeam { get; set; }

    public string NameTeam { get; set; } = null!;

    public int NumberMembersTeam { get; set; }

    public virtual int IdUser { get; set; }
}