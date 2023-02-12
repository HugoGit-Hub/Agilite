namespace Agilite.Entities.Entities;

public partial class User
{
    public int IdUser { get; set; }

    public string FirstNameUser { get; set; } = null!;

    public string LastNameUser { get; set; } = null!;

    public string EmailUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public int EnumRoleUser { get; set; }

    public string DateCreationUser { get; set; } = null!;

    public int? AgeUser { get; set; }

    public virtual ICollection<Planning> Plannings { get; } = new List<Planning>();

    public virtual ICollection<UserMessageContact> UserMessageContacts { get; } = new List<UserMessageContact>();

    public virtual ICollection<UserTeamTeamRole> UserTeamTeamRoles { get; } = new List<UserTeamTeamRole>();
}
