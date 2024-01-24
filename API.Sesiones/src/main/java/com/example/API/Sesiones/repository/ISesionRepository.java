package com.example.API.Sesiones.repository;

import org.springframework.stereotype.Repository;
import com.example.API.Sesiones.model.SesionModel;
import org.springframework.data.repository.CrudRepository;

@Repository
public interface ISesionRepository extends CrudRepository<SesionModel, Integer>{
    
}
