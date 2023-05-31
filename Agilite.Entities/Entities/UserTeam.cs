namespace Agilite.Entities.Entities;

public class UserTeam
{
    public int IdUser { get; set; }

    public int IdTeam { get; set; }

    public string RoleUserTeam { get; set; } = null!;

    public User IdUserNavigation { get; set; } = null!;

    public Team IdTeamNavigation { get; set; } = null!;
}