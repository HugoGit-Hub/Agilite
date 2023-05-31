namespace Agilite.DataTransferObject.DTOs;

public class JobDto
{
    public int IdJob { get; set; }

    public string NameJob { get; set; } = null!;

    public int NumberJob { get; set; }

    public string? TextJob { get; set; }

    public DateTime? StartLogTimeJob { get; set; }

    public DateTime? EndLogTimeJob { get; set; }
}