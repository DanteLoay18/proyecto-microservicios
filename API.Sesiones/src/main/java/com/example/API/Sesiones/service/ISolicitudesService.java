package com.example.API.Sesiones.service;

import java.util.List;

import com.example.API.Sesiones.model.SolicitudesModel;

public interface ISolicitudesService {
    public SolicitudesModel add (SolicitudesModel solicitudesModel);
    public SolicitudesModel update (SolicitudesModel solicitudesModel);
    public boolean delete (int id);
    public List<SolicitudesModel> findAll();
    public SolicitudesModel findById(int id);
}
