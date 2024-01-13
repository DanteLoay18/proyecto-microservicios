namespace API.Docentes.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Docente
        {
            public const string Controller = Base + "/docente";
            public const string FindDocenteById = "findDocenteById/{id}";
            public const string FindDocentesPaginated = "findDocentesPaginated";
            public const string FindDocentesByEscuela = "findDocentesByEscuela/{idEscuela}";
            public const string FindDocentesByFacultad= "findDocentesByFacultad/{idFacultad}";
            public const string CreateDocente = "createDocente";
            public const string UpdateDocente = "updateDocente";
            public const string DeleteDocente = "deleteDocente";
        }
    }
}
