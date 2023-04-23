using System;

namespace Agilite.UI.Models;

class PlanningModel
{
    public int IdPlanning { get; set; }

    public int UserIdUser { get; set; }

    public DateTime StartDatePlanning { get; set; }

    public DateTime EndDatePlanning { get; set; }
}
