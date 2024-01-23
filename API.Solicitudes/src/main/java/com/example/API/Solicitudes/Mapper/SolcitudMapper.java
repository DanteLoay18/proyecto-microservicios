package com.example.API.Solicitudes.Mapper;

import org.springframework.stereotype.Component;

import com.example.API.Solicitudes.dto.SolicitudRequest;
import com.example.API.Solicitudes.model.SolicitudModel;

@Component
public class SolcitudMapper {

    public SolicitudRequest entityToDto(SolicitudModel solcitudModel){
        SolicitudRequest dto = new SolicitudRequest();
        dto.setComentario(solcitudModel.getComentario());
        dto.setEscuela(solcitudModel.getEscuela());
        dto.setTipoSolicitud(solcitudModel.getTipoSolicitud());
        dto.setFacultad(solcitudModel.getFacultad());
        dto.setExpediente(solcitudModel.getExpediente());
        return dto;
    }

    public SolicitudModel dtoTOEntity(SolicitudRequest dto){
        SolicitudModel solicitudModel = new SolicitudModel();
        solicitudModel.setExpediente(dto.getExpediente());
        solicitudModel.setEscuela(dto.getEscuela());
        solicitudModel.setFacultad(dto.getFacultad());
        solicitudModel.setTipoSolicitud(dto.getTipoSolicitud());
        solicitudModel.setComentario(dto.getComentario());
        return solicitudModel;
    }
}
