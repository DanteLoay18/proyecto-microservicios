package com.example.API.Solicitudes.model;

import java.io.Serializable;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;

@Entity
@Table(name = "solicitud")
public class SolicitudModel implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @Column(name = "tipoSolicitud")
    private Integer tipoSolicitud;

    @Column(name = "expediente")
    private String expediente;

    @Column(name = "esEliminado")
    private boolean isDeleted;

    @Column(name = "escuela")
    private Integer escuela;

    @Column(name = "facultad")
    private Integer facultad;

    @Column(name = "comentario")
    private String comentario;

    @Column(name = "observacion")
    private String observacion;

    @Column(name = "esRevisado")
    private boolean esRevisado;

    @Column(name = "esAceptado")
    private boolean esAceptado;

    public SolicitudModel() {
        this.setEsAceptado(false);
        this.setEsEliminado(false);
        this.setObservacion("");
        this.setEsRevisado(false);
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
    public void setObservacion(String observacion) {
        this.observacion = observacion;
    }
    public void setEsEliminado(boolean isDeleted) {
        this.isDeleted = isDeleted;
    }

    public void setEsRevisado(boolean esRevisado) {
        this.esRevisado = esRevisado;
    }

    public void setEsAceptado(boolean esAceptado) {
        this.esAceptado = esAceptado;
    }
}
