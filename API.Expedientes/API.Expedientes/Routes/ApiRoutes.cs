namespace API.Docentes.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Expediente
        {
            public const string Controller = Base + "/expediente";
            public const string GetExpedienteById = "findExpedienteById/{id}";
            public const string GetAllExpedientes = "findAllExpedientes";
            public const string CreateExpediente= "createExpediente";
            public const string UpdateExpediente = "updateExpediente";
            public const string ValidarExpediente = "validarExpediente";
            public const string DeleteExpediente = "deleteExpediente";
        }
    }
}
