namespace Agilite.Entities.Entities;

public partial class Contact
{
    public int IdContact { get; set; }

    public string NameContact { get; set; } = null!;

    public sbyte ArchivedContact { get; set; }

    public virtual ICollection<UserMessageContact> UserMessageContacts { get; } = new List<UserMessageContact>();
}
