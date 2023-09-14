namespace Agilite.UI.Message;

public class ShowSprintsButtonsMessage
{
    public int IdProject { get; }
    public bool DisplaySprintsButtons { get; }

    public ShowSprintsButtonsMessage(int idProject, bool displaySprintsButtons)
    {
        IdProject = idProject;
        DisplaySprintsButtons = displaySprintsButtons;
    }
}