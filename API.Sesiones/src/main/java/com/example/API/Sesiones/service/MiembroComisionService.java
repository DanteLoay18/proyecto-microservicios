package com.example.API.Sesiones.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.API.Sesiones.model.MiembroComisionModel;
import com.example.API.Sesiones.repository.IMiembroComisionRepository;

@Service
public class MiembroComisionService implements IMiembroComisionService{
    
    @Autowired
    private IMiembroComisionRepository miembroComisionRepository;

    @Override
    public MiembroComisionModel add(MiembroComisionModel miembroComisionModel) {
        return miembroComisionRepository.save(miembroComisionModel);
    }

    @Override
    public MiembroComisionModel update(MiembroComisionModel miembroComisionModel){
        return miembroComisionRepository.save(miembroComisionModel);
    }

    @Override
    public boolean delete(int id){
        miembroComisionRepository.deleteById(id);
        return true;
    }

    @Override
    public List<MiembroComisionModel> findAll(){
        return(List<MiembroComisionModel>) miembroComisionRepository.findAll();
    }

    @Override
    public MiembroComisionModel findById(int id){
        Optional<MiembroComisionModel> model = miembroComisionRepository.findById(id);
        return model.get();
    }
}
