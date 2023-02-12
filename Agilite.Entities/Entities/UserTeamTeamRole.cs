namespace Agilite.Entities.Entities;

public partial class UserTeamTeamRole
{
    public int UserIdUser { get; set; }

    public int TeamIdTeam { get; set; }

    public int TeamRoleIdTeamRole { get; set; }

    public DateTime DateTimeUserTeamTeamRole { get; set; }

    public virtual Team TeamIdTeamNavigation { get; set; } = null!;

    public virtual TeamRole TeamRoleIdTeamRoleNavigation { get; set; } = null!;

    public virtual User UserIdUserNavigation { get; set; } = null!;
}
