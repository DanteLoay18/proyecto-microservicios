export class DocenteRoutes{
    static Docente="docente";

    static DocentesGetAllPaginated="findAllDocentesPaginated";
    static DocentesByBusqueda="findByBusqueda";
    static DocentesByEscuela="findByEscuela";
    static DocentesByFacultad="findByFacultad";
    static DocenteById="findDocenteById/:idDocente";
    static DocentesListado="findAllDocentes";
    static CreateDocente = "create";
    static UpdateDocente = "update/:idDocente";
    static ModificarEstado= "modificarEstado/:idDocente"
}