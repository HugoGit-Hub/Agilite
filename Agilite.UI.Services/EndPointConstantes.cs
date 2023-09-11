namespace Agilite.UI.Services;

public static class EndPointConstantes
{
    public const string ApiAddress = "https://localhost:7097";

    public const string CreateMessage = "/api/Message/CreateMessage";
    public const string UpdateMessage = "/api/Message/UpdateMessage";
    public const string AllMessages = "/api/Message/GetAllMessages";
    public const string Message = "/api/Message/GetMessage";
    public const string DeleteMessage = "/api/Message/DeleteMessage";

    public const string CreateObjective = "/api/Objective/CreateObjective";
    public const string UpdateObjective = "/api/Objective/UpdateObjective";
    public const string GetAllObjectivesOfOneSprint = "/api/Objective/GetAllObjectivesOfOneSprint";
    public const string AllObjectives = "/api/Objective/GetAllObjectives";
    public const string Objective = "/api/Objective/GetObjective";
    public const string DeleteObjective = "/api/Objective/DeleteObjective";

    public const string CreateProject = "/api/Project/CreateProject";
    public const string UpdateProject = "/api/Project/UpdateProject";
    public const string AllProjects = "/api/Project/GetAllProjects";
    public const string AllProjectsOfOneTeam = "/api/Project/GetAllProjectsOfOneTeam";
    public const string Project = "/api/Project/GetProject";
    public const string DeleteProject = "/api/Project/DeleteProject";

    public const string CreateSprint = "/api/Sprint/Create";
    public const string UpdateSprint = "/api/Sprint/UpdateSprint";
    public const string AllSprints = "/api/Sprint/GetAllSprints";
    public const string AllSprintsOfOneProject = "/api/Sprint/GetAllSprintsOfOneProject";
    public const string Sprint = "/api/Sprint/Get";
    public const string DeleteSprint = "/api/Sprint/DeleteSprint";

    public const string CreateTask = "/api/Task/CreateTask";
    public const string UpdateTask = "/api/Task/UpdateTask";
    public const string AllTasks = "/api/Task/GetAllTasks";
    public const string Task = "/api/Task/GetTask";
    public const string DeleteTask = "/api/Task/DeleteTask";

    public const string CreateTeam = "/api/Team/CreateTeam";
    public const string UpdateTeam = "/api/Team/UpdateTeam";
    public const string AllTeams = "/api/Team/GetAllTeams";
    public const string AllTeamsOfOneUser = "/api/Team/GetAllTeamsOfOneUser";
    public const string Team = "/api/Team/GetTeam";
    public const string DeleteTeam = "/api/Team/DeleteTeam";

    public const string CreateUser = "/api/User/CreateUser";
    public const string UpdateUser = "/api/User/UpdateUser";
    public const string AllUsers = "/api/User/GetAllUsers";
    public const string User = "/api/User/GetUser";
    public const string UserByEmail = "/api/User/GetUserByEmail";
    public const string DeleteUser = "/api/User/DeleteUser";

    public const string Login = "/api/Authentication/Login";
}