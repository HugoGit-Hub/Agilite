using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Services.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agilite.UI.Data;

public interface IContactDataProvider
{
    Task<IEnumerable<ContactDto>?> GetAsync();
}

public class ContactDataProvider : IContactDataProvider
{
    private readonly IContactService _contactService;

    public ContactDataProvider(IContactService contactService)
    {
        _contactService = contactService;
    }

    public Task<IEnumerable<ContactDto>?> GetAsync()
    {
        return _contactService.GetAll();
    }
}