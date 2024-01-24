package com.example.API.Sesiones.constants;

public class MensajeParametrizados {
    public static final String MENSAJE_CREAR_EXITOSO = "Se registro exitosamente.";
    public static final String MENSAJE_ELIMINAR_EXITOSO = "Se elimino correctamente el registro.";
    public static final String MENSAJE_MODIFICAR_EXITOSO = "Se modifico correctamente el registro.";
    public static final String MENSAJE_ERROR_NO_ENCONTRADO = "No se encontro el registro. ";
    public static final String MENSAJE_ERROR_BASE_DATOS = "Error en la base de datos: ";
    public static final String MENSAJE_ERROR_INTERNO_SERVIDOR = "Error interno del servidor: ";
    public static final String MENSAJE_ELIMINAR_PACIENTE_EXITOSO = "PACIENTE eliminado exitosamente";
    public static final String MENSAJE_ERROR = "Error del servidor ";


    public static String errorBaseDatos(String mensajeError) {
        return MENSAJE_ERROR_BASE_DATOS.replace("{}", mensajeError);
    }

    public static String errorServidor(String mensajeError) {
        return MENSAJE_ERROR_INTERNO_SERVIDOR.replace("{}", mensajeError);
    }
}
