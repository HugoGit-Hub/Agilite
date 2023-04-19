using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Services.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agilite.UI.Data;

public interface IContactDataProvider
{
    Task<IEnumerable<ContactDto>> GetAll();
}

public class ContactDataProvider : IContactDataProvider
{
    private readonly IContactService _contactService;

    public ContactDataProvider(IContactService contactService)
    {
        _contactService = contactService;
    }

    public Task<IEnumerable<ContactDto>> GetAll()
    {
        return _contactService.GetAll();
    }
}