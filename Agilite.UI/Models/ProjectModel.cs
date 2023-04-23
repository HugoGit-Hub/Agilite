using System;

namespace Agilite.UI.Models;

class ProjectModel
{
    public int IdProject { get; set; }

    public int TeamIdTeam { get; set; }

    public string NameProject { get; set; } = null!;

    public DateTime DateCreationProject { get; set; }

    public string? DateEnded { get; set; }
}
