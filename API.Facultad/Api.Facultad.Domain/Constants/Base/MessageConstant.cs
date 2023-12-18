namespace API.Catalogo.Domain.Constants.Base
{
    public static class MessageConstant
    {
        public const string OkRequestRegistro = "Se ha creado el registro correctamente";
        public const string OkRequestUpdate = "Se ha actualizado el registro correctamente";
        public const string BadRequest = "Se ha encontrado errores en la petición";
        public const string InternalError = "Ha ocurrido un error, por favor vuelva a intentar...";
        public const string NoContentForRequest = "No se han encontrado datos, para su petición";
        public const string NotFoundRequest = "No se ha encontrado la solicitud. Recurso no encontrado. ";
    }
}
