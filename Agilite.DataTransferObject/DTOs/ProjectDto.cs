namespace Agilite.DataTransferObject.DTOs;

public class ProjectDto
{
    public int IdProject { get; set; }

    public string NameProject { get; set; } = null!;

    public DateTime DateCreationProject { get; set; }

    public DateTime DateEndedProject { get; set; }
}