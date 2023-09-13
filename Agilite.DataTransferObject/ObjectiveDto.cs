namespace Agilite.DataTransferObject;

public class ObjectiveDto
{
    public int IdObjective { get; set; }

    public int FkObjectiveType { get; set; }

    public string NameObjective { get; set; } = null!;

    public int NumberObjective { get; set; }

    public string? TextObjective { get; set; }
}