package com.example.API.Sesiones.service;

import java.util.List;

import com.example.API.Sesiones.model.MiembroComisionModel;

public interface IMiembroComisionService {
    public MiembroComisionModel add (MiembroComisionModel miembroComisionModel);
    public MiembroComisionModel update (MiembroComisionModel miembroComisionModel);
    public boolean delete (int id);
    public List<MiembroComisionModel> findAll();
    public MiembroComisionModel findById(int id);
}
