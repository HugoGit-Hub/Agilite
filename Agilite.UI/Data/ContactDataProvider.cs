using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agilite.UI.Data;

public interface IContactDataProvider
{
    Task<IEnumerable<ContactDto>> GetAll();
}

public class ContactDataProvider : IContactDataProvider
{
    public async Task<IEnumerable<ContactDto>> GetAll()
    {
        var contactsClient = App.AppHost.Services.GetRequiredService<IContactService>();
        var contacts = await contactsClient.GetAll();
        return contacts;
    }
}