using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface IMessageService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_MESSAGE)]
    public MessageDto Create(MessageDto entity);

    [Put(EndPointConstantes.UPDATE_MESSAGE)]
    public MessageDto Update(MessageDto entity);

    [Get(EndPointConstantes.GET_ALL_MESSAGES)]
    public Task<IEnumerable<MessageDto>> GetAll();

    [Get(EndPointConstantes.GET_MESSAGE)]
    public MessageDto Get(int id);

    [Delete(EndPointConstantes.DELETE_MESSAGE)]
    public MessageDto Delete(MessageDto entity);
}