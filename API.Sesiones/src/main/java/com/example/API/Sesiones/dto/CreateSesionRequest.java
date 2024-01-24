package com.example.API.Sesiones.dto;

import java.sql.Date;

public class CreateSesionRequest {

    private String numeroSesion;
    private String facultad;
    private Date fechaSesion;
    private String presidente;
    private String miembro1;
    private String miembro2;
    private String miembro3;

    // Getter y Setter para 'numeroSesion'
    public String getNumeroSesion() {
        return numeroSesion;
    }

    public void setNumeroSesion(String numeroSesion) {
        this.numeroSesion = numeroSesion;
    }

    public String getFacultad() {
        return facultad;
    }

    public void setFacultad(String facultad) {
        this.facultad = facultad;
    }

    // Getter y Setter para 'fechaSesion'
    public Date getFechaSesion() {
        return fechaSesion;
    }

    public void setFechaSesion(Date fechaSesion) {
        this.fechaSesion = fechaSesion;
    }

    // Getter y Setter para 'presidente'
    public String getPresidente() {
        return presidente;
    }

    public void setPresidente(String presidente) {
        this.presidente = presidente;
    }

    // Getter y Setter para 'miembro1'
    public String getMiembro1() {
        return miembro1;
    }

    public void setMiembro1(String miembro1) {
        this.miembro1 = miembro1;
    }

    // Getter y Setter para 'miembro2'
    public String getMiembro2() {
        return miembro2;
    }

    public void setMiembro2(String miembro2) {
        this.miembro2 = miembro2;
    }

    // Getter y Setter para 'miembro3'
    public String getMiembro3() {
        return miembro3;
    }

    public void setMiembro3(String miembro3) {
        this.miembro3 = miembro3;
    }
}
