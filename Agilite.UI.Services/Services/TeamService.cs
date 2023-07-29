using Agilite.UI.Services.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public interface ITeamService
{
}

public class TeamService : ITeamService
{
    private readonly IUserRefitService _refitService;
    private readonly IMapper _mapper;

    public TeamService(IUserRefitService refitService, IMapper mapper)
    {
        _refitService = refitService;
        _mapper = mapper;
    }
}