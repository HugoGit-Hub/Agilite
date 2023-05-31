namespace Agilite.Entities.Entities;

public class UserContact
{
    public int IdUser { get; set; }
    
    public int IdContact { get; set; }

    public User IdUserNavigation { get; set; } = null!;

    public Contact IdContactNavigation { get; set; } = null!;
}