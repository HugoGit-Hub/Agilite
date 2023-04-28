using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Data;
using System.Collections.ObjectModel;
using System.Linq;

namespace Agilite.UI.ViewModels;

public class ContactsViewModel
{
    private readonly IContactDataProvider _contactDataProvider;

    public ContactsViewModel(IContactDataProvider contactDataProvider)
    {
        _contactDataProvider = contactDataProvider;
    }

    public ObservableCollection<ContactDto> Contacts { get; } = new();

    public void LoadContacts()
    {
        if (Contacts.Any())
        {
            return;
        }

        var contacts = _contactDataProvider.GetAll();
        foreach (var contact in contacts!)
        {
            Contacts.Add(contact);
        }
    }
}
