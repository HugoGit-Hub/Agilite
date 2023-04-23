using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Agilite.UI.ViewModels;

public class ContactsViewModel
{
    private readonly IContactDataProvider _contactDataProvider;

    public ContactsViewModel(IContactDataProvider contactDataProvider)
    {
        _contactDataProvider = contactDataProvider;
    }

    public ObservableCollection<ContactDto> Contacts { get; } = new();

    public async Task LoadAsync()
    {
        if (Contacts.Any())
        {
            return;
        }

        var contacts = await _contactDataProvider.GetAll();
        foreach (var contact in contacts!)
        {
            Contacts.Add(contact);
        }
    }
}
