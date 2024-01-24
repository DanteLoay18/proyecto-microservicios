package com.example.API.Solicitudes.constantes;

public class MensajesParametrizados {
    public static final String MENSAJE_CREAR_SOLICITUD_EXITOSO = "Se registro exitosamente.";
    public static final String MENSAJE_NO_ENCONTRADO_ID = "MS-SOLICITUD -Registro no encontrado: ";
    public static final String MENSAJE_EDITADO_EXITOSO = "MS-SOLICITUD - Registro editado exitosamente";
    public static final String MENSAJE_ERROR_BASE_DATOS = "MS-SOLICITUD - Error en la base de datos: ";
    public static final String MENSAJE_ERROR_INTERNO_SERVIDOR = "MS-SOLICITUD - Error interno del servidor: ";
    public static final String MENSAJE_ELIMINAR_EXITOSO = "MS-SOLICITUD - Registro eliminado exitosamente";
    public static final String MENSAJE_ERROR = "MS-SOLICITUD - Error ";


    public static String solicitudNoEncontradoPorId(int idSolicitud) {
        return MENSAJE_NO_ENCONTRADO_ID.replace("{}", String.valueOf(idSolicitud));
    }


    public static String errorServidor(String mensajeError) {
        return MENSAJE_ERROR_INTERNO_SERVIDOR.replace("{}", mensajeError);
    }

}
