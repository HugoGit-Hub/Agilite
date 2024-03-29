﻿using Agilite.UI.Models.Models;
using Agilite.UI.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public interface IObjectiveService
{
    public Task<IEnumerable<ObjectiveModel>> GetAllObjectivesOfOneSprint(int id);
}

public class ObjectiveService : IObjectiveService
{
    private readonly IMapper _mapper;
    private readonly IObjectiveRefit _objectiveRefitService;

    public ObjectiveService(IMapper mapper, IObjectiveRefit objectiveRefitService)
    {
        _mapper = mapper;
        _objectiveRefitService = objectiveRefitService;
    }

    public async Task<IEnumerable<ObjectiveModel>> GetAllObjectivesOfOneSprint(int id)
    {
        var result = await _objectiveRefitService.GetAllOfOneSprint(id);

        return _mapper.Map<IEnumerable<ObjectiveModel>>(result);
    }
}