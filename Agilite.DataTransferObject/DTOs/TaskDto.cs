namespace Agilite.DataTransferObject.DTOs;

public class TaskDto
{
    public int IdTask { get; set; }

    public int ObjectiveIdObjective { get; set; }

    public string NameTask { get; set; } = null!;

    public int NumberTask { get; set; }

    public int EnumTypeTask { get; set; }

    public int EnumStateTask { get; set; }

    public string? TextTask { get; set; }

    public DateTime? StartLogTimeTask { get; set; }

    public DateTime? EndLogTimeTask { get; set; }
}