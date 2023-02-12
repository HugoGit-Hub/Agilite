namespace Agilite.Entities.Entities;

public partial class Message
{
    public int IdMessage { get; set; }

    public string? TextMessage { get; set; }

    public virtual ICollection<UserMessageContact> UserMessageContacts { get; } = new List<UserMessageContact>();
}
