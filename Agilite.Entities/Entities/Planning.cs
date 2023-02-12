namespace Agilite.Entities.Entities;

public partial class Planning
{
    public int IdPlanning { get; set; }

    public int UserIdUser { get; set; }

    public DateTime StartDatePlanning { get; set; }

    public DateTime EndDatePlanning { get; set; }

    public virtual User UserIdUserNavigation { get; set; } = null!;
}
