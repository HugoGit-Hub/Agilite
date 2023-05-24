namespace Agilite.Entities.Entities;

public class User
{
    public int IdUser { get; set; }

    public string FirstNameUser { get; set; } = null!;

    public string LastNameUser { get; set; } = null!;

    public string EmailUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public DateTime DateCreationUser { get; set; }

    public int AgeUser { get; set; }

    public bool ArchivedUser { get; set; }

    public virtual IEnumerable<UserContact> UserContacts { get; set; } = new List<UserContact>();

    public virtual IEnumerable<UserTeam> UserTeams { get; set; } = new List<UserTeam>();
}
