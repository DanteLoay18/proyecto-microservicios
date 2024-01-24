package com.example.API.Sesiones.dto;


public class AgregarSolicitudesSesionRequest {
    
    private Integer idSesion;
    private Integer idSolicitud;
    private String observacion;

    public Integer getIdSesion() {
        return idSesion;
    }

    public void setIdSesion(Integer idSesion) {
        this.idSesion = idSesion;
    }

    // Getter y Setter para idSolicitud
    public Integer getIdSolicitud() {
        return idSolicitud;
    }

    public void setIdSolicitud(Integer idSolicitud) {
        this.idSolicitud = idSolicitud;
    }

    // Getter y Setter para observacion
    public String getObservacion() {
        return observacion;
    }

    public void setObservacion(String observacion) {
        this.observacion = observacion;
    }

}
