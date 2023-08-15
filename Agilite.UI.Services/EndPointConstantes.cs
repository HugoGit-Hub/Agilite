namespace Agilite.UI.Services;

public static class EndPointConstantes
{
    public const string API_ADDRESS = "https://localhost:7097";

    public const string CREATE_MESSAGE = "/api/Message/CreateMessage";
    public const string UPDATE_MESSAGE = "/api/Message/UpdateMessage";
    public const string GET_ALL_MESSAGES = "/api/Message/GetAllMessages";
    public const string GET_MESSAGE = "/api/Message/GetMessage";
    public const string DELETE_MESSAGE = "/api/Message/DeleteMessage";

    public const string CREATE_OBJECTIVE = "/api/Objective/CreateObjective";
    public const string UPDATE_OBJECTIVE = "/api/Objective/UpdateObjective";
    public const string GET_ALL_OBJECTIVES = "/api/Objective/GetAllObjectives";
    public const string GET_OBJECTIVE = "/api/Objective/GetObjective";
    public const string DELETE_OBJECTIVE = "/api/Objective/DeleteObjective";

    public const string CREATE_PROJECT = "/api/Project/CreateProject";
    public const string UPDATE_PROJECT = "/api/Project/UpdateProject";
    public const string GET_ALL_PROJECTS = "/api/Project/GetAllProjects";
    public const string GET_ALL_PROJECTS_OF_ONE_TEAM = "/api/Project/GetAllProjectsOfOneTeam";
    public const string GET_PROJECT = "/api/Project/GetProject";
    public const string DELETE_PROJECT = "/api/Project/DeleteProject";

    public const string CREATE_SPRINT = "/api/Sprint/Create";
    public const string UPDATE_SPRINT = "/api/Sprint/UpdateSprint";
    public const string GET_ALL_SPRINTS = "/api/Sprint/GetAllSprints";
    public const string GET_ALL_SPRINTS_OF_ONE_PROJECT = "/api/Sprint/GetAllSprintsOfOneProject";
    public const string GET_SPRINT = "/api/Sprint/GetSprint";
    public const string DELETE_SPRINT = "/api/Sprint/DeleteSprint";

    public const string CREATE_TASK = "/api/Task/CreateTask";
    public const string UPDATE_TASK = "/api/Task/UpdateTask";
    public const string GET_ALL_TASKS = "/api/Task/GetAllTasks";
    public const string GET_TASK = "/api/Task/GetTask";
    public const string DELETE_TASK = "/api/Task/DeleteTask";

    public const string CREATE_TEAM = "/api/Team/CreateTeam";
    public const string UPDATE_TEAM = "/api/Team/UpdateTeam";
    public const string GET_ALL_TEAMS = "/api/Team/GetAllTeams";
    public const string GET_ALL_TEAMS_OF_ONE_USER = "/api/Team/GetAllTeamsOfOneUser";
    public const string GET_TEAM = "/api/Team/GetTeam";
    public const string DELETE_TEAM = "/api/Team/DeleteTeam";

    public const string CREATE_USER = "/api/User/CreateUser";
    public const string UPDATE_USER = "/api/User/UpdateUser";
    public const string GET_ALL_USERS = "/api/User/GetAllUsers";
    public const string GET_USER = "/api/User/GetUser";
    public const string GET_USER_BY_EMAIL = "/api/User/GetUserByEmail";
    public const string DELETE_USER = "/api/User/DeleteUser";

    public const string LOGIN = "/api/Authentication/Login";
}