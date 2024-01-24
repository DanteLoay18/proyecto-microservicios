package com.example.API.Sesiones.mapper;

import java.util.List;

import org.springframework.stereotype.Component;

import com.example.API.Sesiones.dto.CreateSesionRequest;
import com.example.API.Sesiones.dto.MiembroComisionResponse;
import com.example.API.Sesiones.dto.SesionResponse;
import com.example.API.Sesiones.dto.SolicitudResponse;
import com.example.API.Sesiones.model.MiembroComisionModel;
import com.example.API.Sesiones.model.SesionModel;

@Component
public class SesionMapper {
    
    public SesionResponse entityToDto(SesionModel sesionModel, List<SolicitudResponse> solicitudes){

        MiembroComisionResponse miembroComisionResponse = new MiembroComisionResponse();
        miembroComisionResponse.setPresidente(sesionModel.getMiembroComision().getPresidente());
        miembroComisionResponse.setMiembro1(sesionModel.getMiembroComision().getMiembro1());
        miembroComisionResponse.setMiembro2(sesionModel.getMiembroComision().getMiembro2());
        miembroComisionResponse.setMiembro3(sesionModel.getMiembroComision().getMiembro3());
        
        SesionResponse dto = new SesionResponse();
        dto.setId(sesionModel.getId());
        dto.setFacultad(sesionModel.getFacultad());
        dto.setFechaSesion(sesionModel.getFechaSesion());
        dto.setNumeroSesion(sesionModel.getNumeroSesion());
        dto.setSolicitudes(solicitudes);
        dto.setMiembroComision(miembroComisionResponse);
        return dto;
    }

    public SesionModel createRequestToEntity(CreateSesionRequest sesionRequest, MiembroComisionModel miembroComisionModel){
        SesionModel sesionModel = new SesionModel();
        sesionModel.setNumeroSesion(sesionRequest.getNumeroSesion());
        sesionModel.setFechaSesion(sesionRequest.getFechaSesion());
        sesionModel.setFacultad(sesionRequest.getFacultad());
        sesionModel.setMiembroComision(miembroComisionModel);
        return sesionModel;
    }

    public SesionModel updateSesionFromRequest(SesionModel sesion, CreateSesionRequest updateSesionRequest) {
        // Actualizar los campos relevantes de la sesión con los datos proporcionados en updateSesionRequest
        sesion.setNumeroSesion(updateSesionRequest.getNumeroSesion());
        sesion.setFacultad(updateSesionRequest.getFacultad());
        sesion.setFechaSesion(updateSesionRequest.getFechaSesion());

        // Actualizar los miembros de la comisión con los datos proporcionados
        MiembroComisionModel miembroComision = sesion.getMiembroComision();
        miembroComision.setPresidente(updateSesionRequest.getPresidente());
        miembroComision.setMiembro1(updateSesionRequest.getMiembro1());
        miembroComision.setMiembro2(updateSesionRequest.getMiembro2());
        miembroComision.setMiembro3(updateSesionRequest.getMiembro3());

        return sesion;
    }

}
