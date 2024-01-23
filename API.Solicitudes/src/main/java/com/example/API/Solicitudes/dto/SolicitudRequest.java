package com.example.API.Solicitudes.dto;

import java.io.Serializable;


public class SolicitudRequest  implements Serializable{

    private Integer tipoSolicitud;
    private String expediente;
    private Integer escuela;
    private Integer facultad;
    private String comentario;

    public Integer getTipoSolicitud() {
        return tipoSolicitud;
    }

    public String getExpediente() {
        return expediente;
    }

    public Integer getEscuela() {
        return escuela;
    }

    public Integer getFacultad() {
        return facultad;
    }

    public String getComentario() {
        return comentario;
    }

    public void setTipoSolicitud(Integer tipoSolicitud) {
        this.tipoSolicitud = tipoSolicitud;
    }

    public void setExpediente(String expediente) {
        this.expediente = expediente;
    }

    public void setEscuela(Integer escuela) {
        this.escuela = escuela;
    }

    public void setFacultad(Integer facultad) {
        this.facultad = facultad;
    }

    public void setComentario(String comentario) {
        this.comentario = comentario;
    }
}
