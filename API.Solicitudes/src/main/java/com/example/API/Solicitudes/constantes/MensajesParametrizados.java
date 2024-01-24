package com.example.API.Solicitudes.constantes;

public class MensajesParametrizados {
    public static final String MENSAJE_CREAR_SOLICITUD_EXITOSO = "Se registro exitosamente.";
    public static final String MENSAJE_PACIENTE_LISTADO = "MS-SOLICITUD - LISTADO EXITOSAMENTE";
    public static final String MENSAJE_PACIENTE_LISTADOID = "MS-SOLICITUD - BUSQUEDA ID EXITOSAMENTE";
    public static final String MENSAJE_PACIENTE_NO_ENCONTRADO = "MS-SOLICITUD - PACIENTE no encontrado:";
    public static final String MENSAJE_PACIENTE_NO_ENCONTRADOELIMINAR = "MS-SOLICITUD - PACIENTE no encontrado a eliminar:";
    public static final String MENSAJE_PACIENTE_NO_ENCONTRADO_ID = "MS-SOLICITUD -PACIENTE no encontrado: ";
    public static final String MENSAJE_PACIENTE_EDITADO_EXITOSO = "MS-SOLICITUD - PACIENTE editado exitosamente";
    public static final String MENSAJE_ERROR_BASE_DATOS = "MS-SOLICITUD - Error en la base de datos: ";
    public static final String MENSAJE_ERROR_INTERNO_SERVIDOR = "MS-SOLICITUD - Error interno del servidor: ";
    public static final String MENSAJE_ELIMINAR_PACIENTE_EXITOSO = "MS-SOLICITUD - PACIENTE eliminado exitosamente";
    public static final String MENSAJE_ERROR = "MS-SOLICITUD - Error ";


    public static String usuarioNoEncontrado(String nombreUsuario) {
        return String.format(MENSAJE_PACIENTE_NO_ENCONTRADO, nombreUsuario);
    }
    public static String solicitudNoEncontradoPorId(int idSolicitud) {
        return MENSAJE_PACIENTE_NO_ENCONTRADO_ID.replace("{}", String.valueOf(idSolicitud));
    }

    public static String errorBaseDatos(String mensajeError) {
        return MENSAJE_ERROR_BASE_DATOS.replace("{}", mensajeError);
    }

    public static String errorServidor(String mensajeError) {
        return MENSAJE_ERROR_INTERNO_SERVIDOR.replace("{}", mensajeError);
    }

}
