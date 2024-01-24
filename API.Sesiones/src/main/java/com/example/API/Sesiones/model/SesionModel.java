package com.example.API.Sesiones.model;

import java.io.Serializable;
import java.sql.Date;
import java.util.List;


import jakarta.persistence.*;


@Entity
@Table(name = "sesion")
public class SesionModel implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    private String numeroSesion;
    private Date fechaSesion;
    private String facultad;


    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn (name="miembro_comision",referencedColumnName="id",nullable=false,unique=true)
    private MiembroComisionModel miembroComision;

    @OneToMany(mappedBy = "sesion", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    private List<SolicitudesModel> solicitudes;

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

    public MiembroComisionModel getMiembroComision() {
        return miembroComision;
    }

    public void setMiembroComision(MiembroComisionModel miembroComision) {
        this.miembroComision = miembroComision;
    }

    public List<SolicitudesModel> getSolicitudes() {
        return solicitudes;
    }

    public void setSolicitudes( List<SolicitudesModel> solicitudes) {
        this.solicitudes = solicitudes;
    }

}
