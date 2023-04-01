using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Agilite.UI.ViewModels;

public class DefaultPageViewModel
{
    private readonly IContactDataProvider _contactDataProvider;

    public DefaultPageViewModel(IContactDataProvider contactDataProvider)
    {
        _contactDataProvider = contactDataProvider;
    }

    public ObservableCollection<ContactDto> Contacts { get; } = new();

    public Task LoadAsync()
    {
        return _contactDataProvider.GetAsync();
    }
}
