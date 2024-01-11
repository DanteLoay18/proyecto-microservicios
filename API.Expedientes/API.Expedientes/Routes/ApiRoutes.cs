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
            public const string CreateExpediente= "createExpediente";
        }
    }
}
