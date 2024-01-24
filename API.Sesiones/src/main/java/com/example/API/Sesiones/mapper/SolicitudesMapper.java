package com.example.API.Sesiones.mapper;

import org.springframework.stereotype.Component;

import com.example.API.Sesiones.dto.AgregarSolicitudesSesionRequest;
import com.example.API.Sesiones.dto.SolicitudDto;
import com.example.API.Sesiones.dto.SolicitudResponse;
import com.example.API.Sesiones.model.SesionModel;
import com.example.API.Sesiones.model.SolicitudesModel;

@Component
public class SolicitudesMapper {
    
    public SolicitudesModel agregarSolicitudesRequestToEntity(AgregarSolicitudesSesionRequest agregarSolicitudesSesionRequest, SesionModel sesionModel){
        SolicitudesModel solicitudesModel = new SolicitudesModel();
        solicitudesModel.setIdSolicitud(agregarSolicitudesSesionRequest.getIdSolicitud());
        solicitudesModel.setSesion(sesionModel);
        return solicitudesModel;
    }

    public SolicitudDto agregarSolicitudesRequestToEntity(AgregarSolicitudesSesionRequest agregarSolicitudesSesionRequest){
        SolicitudDto solicitudDto = new SolicitudDto();
        solicitudDto.setId(agregarSolicitudesSesionRequest.getIdSolicitud());
        solicitudDto.setObservacion(agregarSolicitudesSesionRequest.getObservacion());
        return solicitudDto;
    }

    public SolicitudResponse entityToDto(SolicitudesModel solicitudesModel){
        SolicitudResponse solicitudResponse = new SolicitudResponse();
        solicitudResponse.setIdSolicitud(solicitudesModel.getIdSolicitud());
        solicitudResponse.setIdSesion(solicitudesModel.getSesion().getId());
        return solicitudResponse;
    }
}
