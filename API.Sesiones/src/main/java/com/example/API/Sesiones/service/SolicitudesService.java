package com.example.API.Sesiones.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.API.Sesiones.model.SolicitudesModel;
import com.example.API.Sesiones.repository.ISolicitudesRepository;

@Service
public class SolicitudesService implements ISolicitudesService{
     @Autowired
    private ISolicitudesRepository solicitudesRepository;

    @Override
    public SolicitudesModel add(SolicitudesModel sesionModel) {
        return solicitudesRepository.save(sesionModel);
    }

    @Override
    public SolicitudesModel update(SolicitudesModel sesionModel){
        return solicitudesRepository.save(sesionModel);
    }

    @Override
    public boolean delete(int id){
        solicitudesRepository.deleteById(id);
        return true;
    }

    @Override
    public List<SolicitudesModel> findAll(){
        return(List<SolicitudesModel>) solicitudesRepository.findAll();
    }

    @Override
    public SolicitudesModel findById(int id){
        Optional<SolicitudesModel> model = solicitudesRepository.findById(id);
        return model.get();
    }
}
