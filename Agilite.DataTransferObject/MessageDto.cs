namespace Agilite.DataTransferObject;

public class MessageDto
{
    public int IdMessage { get; set; }

    public string? TextMessage { get; set; }

    public bool ArchivedMessage { get; set; }
}