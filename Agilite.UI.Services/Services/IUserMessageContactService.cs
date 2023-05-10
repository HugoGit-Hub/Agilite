using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services;

public interface IUserMessageContactService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_USER_MESSAGE_CONTACT)]
    public UserMessageContactDto Create(UserMessageContactDto entity);

    [Put(EndPointConstantes.UPDATE_USER_MESSAGE_CONTACT)]
    public UserMessageContactDto Update(UserMessageContactDto entity);

    [Get(EndPointConstantes.GET_ALL_USER_MESSAGE_CONTACTS)]
    public Task<IEnumerable<UserMessageContactDto>> GetAll();

    [Get(EndPointConstantes.GET_USER_MESSAGE_CONTACT)]
    public UserMessageContactDto Get(int id);

    [Delete(EndPointConstantes.DELETE_USER_MESSAGE_CONTACT)]
    public UserMessageContactDto Delete(UserMessageContactDto entity);
}