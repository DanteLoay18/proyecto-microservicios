package com.example.API.Sesiones.dto;

import java.io.Serializable;
import java.sql.Date;
import java.util.List;

import com.example.API.Sesiones.model.MiembroComisionModel;


public class SesionResponse implements Serializable{

    private Integer id;
    private String numeroSesion;
    private Date fechaSesion;
    private String facultad;
    private List<SolicitudResponse> solicitudes;
    private MiembroComisionResponse miembroComision;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getNumeroSesion() {
        return numeroSesion;
    }

    public void setNumeroSesion(String numeroSesion) {
        this.numeroSesion = numeroSesion;
    }

    public Date getFechaSesion() {
        return fechaSesion;
    }

    public void setFechaSesion(Date fechaSesion) {
        this.fechaSesion = fechaSesion;
    }

    public String getFacultad() {
        return facultad;
    }

    public void setFacultad(String facultad) {
        this.facultad = facultad;
    }

    public List<SolicitudResponse> getSolicitudes() {
        return solicitudes;
    }

    public void setSolicitudes( List<SolicitudResponse> solicitudes) {
        this.solicitudes = solicitudes;
    }

    public MiembroComisionResponse getMiembroComision() {
        return miembroComision;
    }

    public void setMiembroComision( MiembroComisionResponse miembroComision) {
        this.miembroComision = miembroComision;
    }
}
