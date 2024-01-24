package com.example.API.Sesiones.repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import com.example.API.Sesiones.model.MiembroComisionModel;

@Repository
public interface IMiembroComisionRepository extends CrudRepository<MiembroComisionModel, Integer>{
    
}
