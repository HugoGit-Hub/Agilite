using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Linq;

namespace Agilite.UI.ViewModels;

public class ContactViewModel : ViewModelBase
{
    private readonly ContactService _contactService;

    public ContactViewModel(ContactService contactService)
    {
        _contactService = contactService;
        LoadContacts();
    }

    public ObservableCollection<ContactModel> Contacts { get; } = new();

    public void LoadContacts()
    {
        if (Contacts.Any())
        {
            return;
        }

        var contacts = _contactService.GetAll().Result;
        foreach (var contact in contacts!)
        {
            Contacts.Add(contact);
        }
    }
}
