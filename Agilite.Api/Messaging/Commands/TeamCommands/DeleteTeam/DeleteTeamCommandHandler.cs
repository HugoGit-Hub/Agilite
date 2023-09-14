using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using Agilite.UnitOfWork.Context;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Api.Messaging.Commands.TeamCommands.DeleteTeam;

public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, TeamDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly AgiliteContext _context;

    public DeleteTeamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, AgiliteContext context)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
    }

    public async Task<TeamDto> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        var team = await _context.Teams
            .Include(e => e.Users)
            .Include(e => e.Projects)
            .Where(e => e.IdTeam == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (team == null) throw new ArgumentNullException();

        var deleted = _unitOfWork.GetRepository<Team>().Delete(team);
        await _unitOfWork.SaveAsync(cancellationToken);

        return _mapper.Map<TeamDto>(deleted);
    }
}