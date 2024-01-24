package com.example.API.Sesiones.model;

import java.util.List;

import jakarta.persistence.*;

@Entity
@Table(name = "miembrocomision")
public class MiembroComisionModel {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    private String presidente;
    private String miembro1;
    private String miembro2;
    private String miembro3;


    @OneToMany(mappedBy = "miembroComision", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    private List<SesionModel> sesiones;

     public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getPresidente() {
        return presidente;
    }

    public void setPresidente(String presidente) {
        this.presidente = presidente;
    }

    public String getMiembro1() {
        return miembro1;
    }

    public void setMiembro1(String miembro1) {
        this.miembro1 = miembro1;
    }

    public String getMiembro2() {
        return miembro2;
    }

    public void setMiembro2(String miembro2) {
        this.miembro2 = miembro2;
    }

    public String getMiembro3() {
        return miembro3;
    }

    public void setMiembro3(String miembro3) {
        this.miembro3 = miembro3;
    }

    public List<SesionModel> getSesiones() {
        return sesiones;
    }

    public void setSesiones(List<SesionModel> sesiones) {
        this.sesiones = sesiones;
    }
}
