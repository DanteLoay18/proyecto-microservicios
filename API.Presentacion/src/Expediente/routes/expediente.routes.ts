export class ExpedienteRoutes{
    static Expediente="expediente";

    static ExpedientesGetAllPaginated="findAllExpedientesPaginated";
    static ExpedientesByBusqueda="findByBusqueda";
    static ExpedienteById="findExpedienteById/:idExpediente";
    static ExpedientesListado="findAllExpedientes";
    static CreateExpediente = "create";
    static UpdateExpediente = "update";
    static ValidarExpediente = "validar";
    static EliminarExpediente= "delete/:idExpediente"
}