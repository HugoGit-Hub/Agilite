namespace Agilite.DataTransferObject.DTOs;

public class ProjectDto
{
    public int IdProject { get; set; }

    public string NameProject { get; set; } = null!;

    public int FkTeam { get; set; }

    public int FkProjectType { get; set; }

    public DateTime DateCreationProject { get; set; }

    public DateTime DateEndedProject { get; set; }
}