namespace Agilite.Entities.Entities;

public class TeamUser
{
    public int TeamIdTeam { get; set; }
    public int UserIdUser { get; set; }
    
    public Team Team { get; set; }
    public User User { get; set; }
}