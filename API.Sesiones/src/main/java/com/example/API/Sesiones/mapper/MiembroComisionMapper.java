package com.example.API.Sesiones.mapper;

import org.springframework.stereotype.Component;

import com.example.API.Sesiones.dto.CreateSesionRequest;
import com.example.API.Sesiones.dto.MiembroComisionResponse;
import com.example.API.Sesiones.model.MiembroComisionModel;

@Component
public class MiembroComisionMapper {
    
    public MiembroComisionModel createRequestToEntity(CreateSesionRequest sesionRequest){
        MiembroComisionModel miembroComisionModel = new MiembroComisionModel();
        miembroComisionModel.setPresidente(sesionRequest.getNumeroSesion());
        miembroComisionModel.setMiembro1(sesionRequest.getMiembro1());
        miembroComisionModel.setMiembro2(sesionRequest.getMiembro2());
        miembroComisionModel.setMiembro3(sesionRequest.getMiembro3());
        return miembroComisionModel;
    }

     public MiembroComisionResponse entityToDto(MiembroComisionModel miembroComisionModel){
        MiembroComisionResponse miembroComisionResponse = new MiembroComisionResponse();
        miembroComisionResponse.setMiembro1(miembroComisionModel.getMiembro1());
        miembroComisionResponse.setMiembro2(miembroComisionModel.getMiembro2());
        return miembroComisionResponse;
    }

}
