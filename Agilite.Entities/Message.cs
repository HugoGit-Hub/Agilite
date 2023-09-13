namespace Agilite.Entities;

public class Message
{
    public int IdMessage { get; set; }

    public int FkReceiverUser { get; set; }

    public int FkSenderUser { get; set; }

    public string? TextMessage { get; set; }

    public bool ArchivedMessage { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
