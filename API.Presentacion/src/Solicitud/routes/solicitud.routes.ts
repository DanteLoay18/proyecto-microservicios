export class SolicitudRoutes{
    static Solicitud="solicitud";
    static SolicitudesGetAllPaginatedNoRevisados="findAllSolicitudesPaginatedNoRevisados";
    static SolicitudesGetAll="findAllSolicitudes";
    static SolicitudById="findSolicitudById/:idSolicitud";
    static SolicitudByIdAndExpediente="findSolicitudConExpedienteById/:idSolicitud";
    static FiltrarTipoSolicitud="filtrarTipoSolicitud/:tipoExpediente";
    static UploadFile = "upload";
    static CreateSolicitud = "create";
    static UpdateSolicitud = "update";
    static CambiarEstadoSolicitud = "cambiar-estado";
    static EliminarSolicitud= "delete/:idSolicitud"
    static CargarArchivo= "upload"
}