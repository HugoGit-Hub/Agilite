using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface IContactRefitService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_CONTACT)]
    public Task<ContactDto> Create(ContactDto entity);

    [Put(EndPointConstantes.UPDATE_CONTACT)]
    public Task<ContactDto> Update(ContactDto entity);

    [Get(EndPointConstantes.GET_ALL_CONTACTS)]
    public Task<IEnumerable<ContactDto>> GetAll();

    [Get(EndPointConstantes.GET_CONTACT)]
    public Task<ContactDto> Get(int id);

    [Delete(EndPointConstantes.DELETE_CONTACT)]
    public Task<ContactDto> Delete(ContactDto entity);
}