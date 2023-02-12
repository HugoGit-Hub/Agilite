namespace Agilite.DataTransferObject.DTOs;

public class ProjectDto
{
    public int IdProject { get; set; }

    public int TeamIdTeam { get; set; }

    public string NameProject { get; set; } = null!;

    public DateTime DateCreationProject { get; set; }

    public string? DateEnded { get; set; }
}