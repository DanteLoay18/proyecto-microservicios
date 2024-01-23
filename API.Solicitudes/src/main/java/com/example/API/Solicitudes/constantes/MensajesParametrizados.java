package com.example.API.Solicitudes.constantes;

public class MensajesParametrizados {
    //public static final String MENSAJE_AUTENTICACION_EXITOSA = "Autenticación exitosa. Token:";
    //public static final String MENSAJE_ERROR_AUTENTICACION = "Error de autenticación. Verifica tu nombre de usuario y contraseña.";
    public static final String MENSAJE_CREAR_SOLICITUD_EXITOSO = "Se registro exitosamente.";
    public static final String MENSAJE_CREAR_PACIENTE_NOEXITOSO = "MSPACIENTE PACIENTE NO CREADO.";
    public static final String MENSAJE_PACIENTE_EXISTENTE = "MSPACIENTE - El PACIENTE ya existe";
    public static final String MENSAJE_PACIENTE_LISTADO = "MSPACIENTE - LISTADO EXITOSAMENTE";
    public static final String MENSAJE_PACIENTE_LISTADOID = "MSPACIENTE - BUSQUEDA ID EXITOSAMENTE";
    public static final String MENSAJE_PACIENTE_NO_ENCONTRADO = "MSPACIENTE - PACIENTE no encontrado:";
    public static final String MENSAJE_PACIENTE_NO_ENCONTRADOELIMINAR = "MSPACIENTE - PACIENTE no encontrado a eliminar:";
    public static final String MENSAJE_PACIENTE_NO_ENCONTRADO_ID = "MSPACIENTE -PACIENTE no encontrado: ";
    public static final String MENSAJE_PACIENTE_EDITADO_EXITOSO = "MSPACIENTE - PACIENTE editado exitosamente";
    public static final String MENSAJE_ERROR_BASE_DATOS = "MSPACIENTE - Error en la base de datos: ";
    public static final String MENSAJE_ERROR_INTERNO_SERVIDOR = "MSPACIENTE - Error interno del servidor: ";
    public static final String MENSAJE_ELIMINAR_PACIENTE_EXITOSO = "MSPACIENTE - PACIENTE eliminado exitosamente";
    public static final String MENSAJE_ERROR = "MSPACIENTE - Error ";


    public static String usuarioNoEncontrado(String nombreUsuario) {
        return String.format(MENSAJE_PACIENTE_NO_ENCONTRADO, nombreUsuario);
    }
    public static String usuarioNoEncontradoPorId(int idUsuario) {
        return MENSAJE_PACIENTE_NO_ENCONTRADO_ID.replace("{}", String.valueOf(idUsuario));
    }

    public static String errorBaseDatos(String mensajeError) {
        return MENSAJE_ERROR_BASE_DATOS.replace("{}", mensajeError);
    }

    public static String errorServidor(String mensajeError) {
        return MENSAJE_ERROR_INTERNO_SERVIDOR.replace("{}", mensajeError);
    }
}
