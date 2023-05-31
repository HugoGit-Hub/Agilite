namespace Agilite.DataTransferObject.DTOs;

public class UserTeamDto
{
    public int IdUser { get; set; }

    public int IdTeam { get; set; }

    public string RoleUserTeam { get; set; } = null!;
}