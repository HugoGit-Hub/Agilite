using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public class SprintViewModel : ObservableObject
{
    private readonly IObjectiveService _objectiveService;
    private readonly ISprintService _sprintService;
    private readonly ICommand _LoadSprintCommand;

    private SprintModel _sprint;

    public ObservableCollection<ObjectiveModel> Objectives { get; }

    public SprintModel Sprint
    {
        get => _sprint;
        set => SetProperty(ref _sprint, value);
    }

    public SprintViewModel(
        IObjectiveService objectiveService,
        ISprintService sprintService)
    {
        WeakReferenceMessenger.Default.Register<SprintModel>(this, GetSprint);

        _objectiveService = objectiveService;
        _sprintService = sprintService;
    }

    private async void GetSprint(object recipient, SprintModel sprint)
    {
        Sprint = await _sprintService.Get(sprint.IdSprint);
    }

    private async void LoadObjectives(int id)
    {
        var result = await _objectiveService.GetAllObjectivesOfOneSprint(id);

        Objectives.Clear();

        foreach (var objective in result)
        {
            Objectives.Add(objective);
        }
    }
}