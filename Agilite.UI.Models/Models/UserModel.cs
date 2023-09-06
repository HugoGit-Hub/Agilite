namespace Agilite.UI.Models.Models;

public class UserModel
{
    public int IdUser { get; set; }

    public string? FirstNameUser { get; set; }

    public string? LastNameUser { get; set; }

    public string? EmailUser { get; set; }

    public string? PasswordUser { get; set; }

    public DateTime DateCreationUser { get; set; }

    public int? AgeUser { get; set; }

    public bool ArchivedUser { get; set; }
}
