using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services;

public interface IContactService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_CONTACT)]
    public Task<IEnumerable<ContactDto>> Create(ContactDto entity);

    [Put(EndPointConstantes.UPDATE_CONTACT)]
    public Task<IEnumerable<ContactDto>> Update(ContactDto entity);

    [Get(EndPointConstantes.GET_ALL_CONTACTS)]
    public Task<IEnumerable<ContactDto>> GetAll();

    [Get(EndPointConstantes.GET_CONTACT)]
    public Task<IEnumerable<ContactDto>> Get(int id);

    [Delete(EndPointConstantes.DELETE_CONTACT)]
    public Task<IEnumerable<ContactDto>> Delete(ContactDto entity);
}