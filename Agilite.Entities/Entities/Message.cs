namespace Agilite.Entities.Entities;

public class Message
{
    public int IdMessage { get; set; }

    public int FkContact { get; set; }

    public string? TextMessage { get; set; }

    public bool ArchivedMessage { get; set; }

    public virtual Contact IdContactNavigation { get; set; } = null!;
}
