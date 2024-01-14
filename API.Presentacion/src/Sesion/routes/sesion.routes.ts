export class SesionRoutes{
    static Sesion="sesion";
    
    static FindUltimaIteracionMiembroComision = "findUltimaIteracionMiembroComision";
    static SesionsGetAllPaginated="findAllSesionesPaginated";
    static SesionsByBusqueda="findByBusqueda";
    static SesionById="findSesionById/:idSesion";
    static SesionSolicitudesById="findSolicitudesByIdSesion";
    static SesionsListado="findAllSesions";
    static CreateSesion = "create";
    static UpdateSesion = "update";
    static AgregarSolicitud = "agregarSolicitud";
}