package com.example.API.Solicitudes.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.API.Solicitudes.model.SolicitudModel;
import com.example.API.Solicitudes.repository.ISolicitudRepository;


@Service
public class SolicitudService implements ISolicitudService{

    @Autowired
    private ISolicitudRepository solicitudRepository;

    @Override
    public SolicitudModel add(SolicitudModel solicitudModel) {
        return solicitudRepository.save(solicitudModel);
    }
}   
