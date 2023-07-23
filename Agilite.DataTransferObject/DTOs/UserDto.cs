using Agilite.Entities.Entities;

namespace Agilite.DataTransferObject.DTOs;

public class UserDto
{
    public int IdUser { get; set; }

    public string FirstNameUser { get; set; } = null!;

    public string LastNameUser { get; set; } = null!;

    public string EmailUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public DateTime DateCreationUser { get; set; }

    public int AgeUser { get; set; }

    public bool ArchivedUser { get; set; }

    public virtual IEnumerable<Message> Messages { get; set; } = new List<Message>();

    public virtual IEnumerable<Team> Teams { get; set; } = new List<Team>();
}
