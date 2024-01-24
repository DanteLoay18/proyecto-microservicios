package com.example.API.Solicitudes.dto;

import jakarta.persistence.Column;

public class SolicitudResponse {
    private Integer id;
    private Integer tipoSolicitud;
    private String expediente;
    private Integer escuela;
    private Integer facultad;
    private String comentario;
    private String observacion;
    private boolean esRevisado;
    private boolean esAceptado;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getObservacion() {
        return observacion;
    }

    public void setObservacion(String id) {
        this.observacion = observacion;
    }

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

    public boolean getEsRevisado() {
        return esRevisado;
    }

    public boolean getEsAceptado() {
        return esAceptado;
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

    public void setEsRevisado(boolean esRevisado) {
        this.esRevisado = esRevisado;
    }

    public void setEsAceptado(boolean esAceptado) {
        this.esAceptado = esAceptado;
    }
}
