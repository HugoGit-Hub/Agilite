namespace Agilite.Entities.Entities;

public partial class UserMessageContact
{
    public int UserIdUser { get; set; }

    public int ContactIdContact { get; set; }

    public int MessageIdMessage { get; set; }

    public DateTime DateTimeUserMessageContact { get; set; }

    public virtual Contact ContactIdContactNavigation { get; set; } = null!;

    public virtual Message MessageIdMessageNavigation { get; set; } = null!;

    public virtual User UserIdUserNavigation { get; set; } = null!;
}
