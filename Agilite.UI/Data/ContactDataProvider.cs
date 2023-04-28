using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Services.Services;
using System.Collections.Generic;

namespace Agilite.UI.Data;

public interface IContactDataProvider
{
    ContactDto Create(ContactDto contactDto);
    ContactDto Update(ContactDto contactDto);
    IEnumerable<ContactDto> GetAll();
    ContactDto Get(int id);
    ContactDto Delete(ContactDto contactDto);
}

public class ContactDataProvider : IContactDataProvider
{
    private readonly IContactService _contactService;

    public ContactDataProvider(IContactService contactService)
    {
        _contactService = contactService;
    }

    public ContactDto Create(ContactDto contactDto)
    {
        var create = _contactService.Create(contactDto);
        return create;
    }

    public ContactDto Delete(ContactDto contactDto)
    {
        var delete = _contactService.Delete(contactDto);
        return delete;
    }

    public IEnumerable<ContactDto> GetAll()
    {
        var contacts = _contactService.GetAll();
        return contacts;
    }

    public ContactDto Get(int id)
    {
        var contact = _contactService.Get(id);
        return contact;
    }

    public ContactDto Update(ContactDto contactDto)
    {
        var update = _contactService.Update(contactDto);
        return update;
    }
}