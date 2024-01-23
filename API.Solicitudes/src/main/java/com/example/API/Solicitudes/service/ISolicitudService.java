package com.example.API.Solicitudes.service;

import java.util.List;

import com.example.API.Solicitudes.model.SolicitudModel;

public interface ISolicitudService {
    public SolicitudModel add (SolicitudModel solicitudModel);
    public SolicitudModel update (SolicitudModel solicitudModel);
    public boolean delete (int id);
    public List<SolicitudModel> findAll();
    public SolicitudModel findById(int id);
}
