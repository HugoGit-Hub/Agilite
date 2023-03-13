namespace Agilite.UI.Models;

internal class ContactModel : ContactModelBase
{
    private int idContact;
    private string? nameContact;
    private bool archivedContact;

    public int IdContact
    {
        get => idContact;
        
        set
        {
            idContact = value;
            OnPropertyChanged(nameof(IdContact));
        }
    }

    public string NameContact
    {
        get => nameContact;

        set
        {
            nameContact = value;
            OnPropertyChanged(nameof(NameContact));
        }
    }

    public bool ArchivedContact
    {
        get => archivedContact;

        set
        {
            archivedContact = value;
            OnPropertyChanged(nameof(ArchivedContact));
        }
    }
}
