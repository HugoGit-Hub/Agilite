namespace Agilite.Entities.Entities;

public partial class TeamRole
{
    public int IdTeamRole { get; set; }

    public string TitleTeamRole { get; set; } = null!;

    public int AccessTeamRole { get; set; }

    public virtual ICollection<UserTeamTeamRole> UserTeamTeamRoles { get; } = new List<UserTeamTeamRole>();
}
