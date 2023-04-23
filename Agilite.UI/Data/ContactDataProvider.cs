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
    public async Task<ContactDto> Create(ContactDto contactDto)
    {
        var contactClient = App.AppHost.Services.GetRequiredService<IContactService>();
        var contact = await contactClient.Create(contactDto);
        return contact;
    }

    public async Task<ContactDto> Update(ContactDto contactDto)
    {
        var contactClient = App.AppHost.Services.GetRequiredService<IContactService>();
        var contact = await contactClient.Update(contactDto);
        return contact;
    }
    
    public async Task<IEnumerable<ContactDto>> GetAll()
    {
        var contactsClient = App.AppHost.Services.GetRequiredService<IContactService>();
        var contacts = await contactsClient.GetAll();
        return contacts;
    }

    public async Task<ContactDto> Get(int id)
    {
        var contactClient = App.AppHost.Services.GetRequiredService<IContactService>();
        var contact = await contactClient.Get(id);
        return contact;
    }

    public async Task<ContactDto> Delete(ContactDto contactDto)
    {
        var contactClient = App.AppHost.Services.GetRequiredService<IContactService>();
        var contact = await contactClient.Delete(contactDto);
        return contact;
    }
}