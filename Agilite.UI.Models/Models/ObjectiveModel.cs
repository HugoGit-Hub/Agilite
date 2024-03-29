﻿namespace Agilite.UI.Models.Models;

public class ObjectiveModel
{
    public int IdObjective { get; set; }

    public int SprintIdSprint { get; set; }

    public string NameObjective { get; set; } = null!;

    public int NumberObjective { get; set; }

    public int EnumTypeObjective { get; set; }

    public string? TextObjective { get; set; }
}
