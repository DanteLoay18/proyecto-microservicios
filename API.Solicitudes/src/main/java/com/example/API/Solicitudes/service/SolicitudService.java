package com.example.API.Solicitudes.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.stereotype.Service;

import com.example.API.Solicitudes.model.SolicitudModel;
import com.example.API.Solicitudes.redis.dbCache;
import com.example.API.Solicitudes.repository.ISolicitudRepository;


@Service
public class SolicitudService implements ISolicitudService{

    @Autowired
    private ISolicitudRepository solicitudRepository;

    @Override
    public SolicitudModel add(SolicitudModel solicitudModel) {
        return solicitudRepository.save(solicitudModel);
    }

    @Override
    public SolicitudModel update(SolicitudModel solicitudModel){
        return solicitudRepository.save(solicitudModel);
    }

    @Override
    public boolean delete(int id){
        solicitudRepository.deleteById(id);
        return true;
    }

    @Override
    @Cacheable(value = dbCache.CACHE_NAME)
    public List<SolicitudModel> findAll(){
        return(List<SolicitudModel>) solicitudRepository.findAll();
    }

    @Override
    public SolicitudModel findById(int id){
        Optional<SolicitudModel> model = solicitudRepository.findById(id);
        return model.get();
    }

}   
