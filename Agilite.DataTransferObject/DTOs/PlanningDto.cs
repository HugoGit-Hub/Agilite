namespace Agilite.DataTransferObject.DTOs;

public class PlanningDto
{
    public int IdPlanning { get; set; }

    public int UserIdUser { get; set; }

    public DateTime StartDatePlanning { get; set; }

    public DateTime EndDatePlanning { get; set; }
}