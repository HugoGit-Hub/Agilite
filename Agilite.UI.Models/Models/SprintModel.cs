﻿namespace Agilite.UI.Models.Models;

public class SprintModel
{
    public int IdSprint { get; set; }

    public int FkProject { get; set; }

    public int NumberSprint { get; set; }

    public DateTime StartDateSprint { get; set; }

    public DateTime EndDateSprint { get; set; }
}
