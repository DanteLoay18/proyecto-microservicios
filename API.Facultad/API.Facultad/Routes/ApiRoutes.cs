namespace API.Facultad.Routes
{
    public static class ApiRoutes
    {

        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Facultad
        {
            public const string Controller = Base + "/facultad";
            public const string FindFacultadById =  "{id}";
            public const string FindEscuelasByFacultad = "findEscuelasByFacultad/{id}";
            public const string FindFacultadesPaginated = "";
            public const string FindFacultades = "findAllFacultades";
            public const string AsignarEncargado = "asignarEncargado";
            public const string DeleteEncargado = "eliminarEncargado";
        }
    }
}
