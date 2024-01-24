package com.example.API.Sesiones.service;

import java.util.List;

import com.example.API.Sesiones.model.SesionModel;

public interface ISesionService {
    public SesionModel add (SesionModel sesionModel);
    public SesionModel update (SesionModel sesionModel);
    public boolean delete (int id);
    public List<SesionModel> findAll();
    public SesionModel findById(int id);
}
