using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public class ContactService
{
    //private readonly IContactRefitService _contactRefitService;
    private readonly IMapper _mapper;

    public ContactService(/*IContactRefitService contactRefitService,*/ IMapper mapper)
    {
        //_contactRefitService = contactRefitService;
        _mapper = mapper;
    }

    //public Task<ContactModel> Create(ContactModel model)
    //{
    //    var dto = _mapper.Map<ContactDto>(model);
    //    var created = _contactRefitService.Create(dto).Result;
    //    return Task.FromResult(_mapper.Map<ContactModel>(created));
    //}

    //public Task<ContactModel> Update(ContactModel model)
    //{
    //    var dto = _mapper.Map<ContactDto>(model);
    //    var updated = _contactRefitService.Update(dto).Result;
    //    return Task.FromResult(_mapper.Map<ContactModel>(updated));
    //}

    //public Task<IEnumerable<ContactModel>> GetAll()
    //{
    //    var getAll = _contactRefitService.GetAll().Result;
    //    return Task.FromResult(_mapper.Map<IEnumerable<ContactModel>>(getAll));
    //}

    //public Task<ContactModel> Get(int id)
    //{
    //    var get = _contactRefitService.Get(id).Result;
    //    return Task.FromResult(_mapper.Map<ContactModel>(get));
    //}

    //public Task<ContactModel> Delete(ContactModel model)
    //{
    //    var dto = _mapper.Map<ContactDto>(model);
    //    var deleted = _contactRefitService.Delete(dto).Result;
    //    return Task.FromResult(_mapper.Map<ContactModel>(deleted));
    //}
}