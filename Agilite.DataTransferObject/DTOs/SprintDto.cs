﻿namespace Agilite.DataTransferObject.DTOs;

public class SprintDto
{
    public int IdSprint { get; set; }

    public int ProjectIdProject { get; set; }

    public int NumberSprint { get; set; }

    public DateTime StartDateSprint { get; set; }

    public DateTime EndDateSprint { get; set; }
}