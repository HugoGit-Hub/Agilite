using Agilite.Entities.Entities;

namespace Agilite.DataTransferObject.DTOs;

public class TeamUserDto
{
    public int TeamIdTeam { get; set; }
    public int UserIdUser { get; set; }

    public Team Team { get; set; }
    public User User { get; set; }
}