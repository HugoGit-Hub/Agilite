using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Refit;

public interface IMessageRefit : IBaseRefitClient
{
    [Post(EndPointConstantes.CreateMessage)]
    public MessageDto Create(MessageDto entity);

    [Put(EndPointConstantes.UpdateMessage)]
    public MessageDto Update(MessageDto entity);

    [Get(EndPointConstantes.AllMessages)]
    public Task<IEnumerable<MessageDto>> GetAll();

    [Get(EndPointConstantes.Message)]
    public MessageDto Get(int id);

    [Delete(EndPointConstantes.DeleteMessage)]
    public MessageDto Delete(MessageDto entity);
}