package com.example.API.Sesiones.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import com.example.API.Sesiones.model.SesionModel;
import com.example.API.Sesiones.repository.ISesionRepository;

@Service
public class SesionService implements ISesionService{
    @Autowired
    private ISesionRepository sesionRepository;

    @Override
    public SesionModel add(SesionModel sesionModel) {
        return sesionRepository.save(sesionModel);
    }

    @Override
    public SesionModel update(SesionModel sesionModel){
        return sesionRepository.save(sesionModel);
    }

    @Override
    public boolean delete(int id){
        sesionRepository.deleteById(id);
        return true;
    }

    @Override
    public List<SesionModel> findAll(){
        return(List<SesionModel>) sesionRepository.findAll();
    }

    @Override
    public SesionModel findById(int id){
        Optional<SesionModel> model = sesionRepository.findById(id);
        return model.get();
    }
}
