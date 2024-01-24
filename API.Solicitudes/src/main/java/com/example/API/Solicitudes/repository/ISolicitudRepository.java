package com.example.API.Solicitudes.repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import com.example.API.Solicitudes.model.SolicitudModel;

@Repository
public interface ISolicitudRepository  extends CrudRepository<SolicitudModel, Integer>{
    
}
