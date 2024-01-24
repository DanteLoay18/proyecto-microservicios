package com.example.API.Sesiones.repository;

import org.springframework.stereotype.Repository;
import org.springframework.data.repository.CrudRepository;
import com.example.API.Sesiones.model.SolicitudesModel;

@Repository
public interface ISolicitudesRepository extends CrudRepository<SolicitudesModel, Integer>{
    
}
