using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Agilite.UI.Message;

public class ShowSprintsButtonsMessage : ValueChangedMessage<bool>
{
    public ShowSprintsButtonsMessage(bool value) 
        : base(value)
    {
    }
}