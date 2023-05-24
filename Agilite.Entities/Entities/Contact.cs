namespace Agilite.Entities.Entities;

public class Contact
{
    public int IdContact { get; set; }

    public string NameContact { get; set; } = null!;

    public bool ArchivedContact { get; set; }

    public IEnumerable<UserContact> UserContacts { get; set; } = new List<UserContact>();

    public IEnumerable<Message> Messages { get; set; } = new List<Message>();
}
