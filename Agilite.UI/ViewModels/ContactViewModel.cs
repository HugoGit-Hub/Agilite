using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Services.Services;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Linq;

namespace Agilite.UI.ViewModels;

public class ContactViewModel : ViewModelBase
{
    private readonly IContactService _contactDataProvider;

    public ContactViewModel(IContactService contactDataProvider)
    {
        _contactDataProvider = contactDataProvider;
        LoadContacts();
    }

    public ObservableCollection<ContactDto> Contacts { get; } = new();

    public void LoadContacts()
    {
        if (Contacts.Any())
        {
            return;
        }

        var contacts = _contactDataProvider.GetAll().Result;
        foreach (var contact in contacts!)
        {
            Contacts.Add(contact);
        }
    }
}
