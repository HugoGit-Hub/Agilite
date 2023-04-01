using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services;

public interface IContactService
{
    [Post(EndPointConstantes.CREATE_CONTACT)]
    public ContactDto Create(ContactDto entity);

    [Put(EndPointConstantes.UPDATE_CONTACT)]
    public ContactDto Update(ContactDto entity);

    [Get(EndPointConstantes.GET_ALL_CONTACTS)]
    public Task<IEnumerable<ContactDto>?> GetAll();

    [Get(EndPointConstantes.GET_CONTACT)]
    public ContactDto Get(int id);

    [Delete(EndPointConstantes.DELETE_CONTACT)]
    public ContactDto Delete(ContactDto entity);
}