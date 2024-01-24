package com.example.API.Solicitudes.Mapper;

import org.springframework.stereotype.Component;

import com.example.API.Solicitudes.dto.SolicitudRequest;
import com.example.API.Solicitudes.dto.SolicitudResponse;
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

    public SolicitudResponse entityToResponse(SolicitudModel solcitudModel){
        SolicitudResponse dto = new SolicitudResponse();
        dto.setId(solcitudModel.getId());
        dto.setComentario(solcitudModel.getComentario());
        dto.setEscuela(solcitudModel.getEscuela());
        dto.setTipoSolicitud(solcitudModel.getTipoSolicitud());
        dto.setFacultad(solcitudModel.getFacultad());
        dto.setExpediente(solcitudModel.getExpediente());
        dto.setEsAceptado(solcitudModel.getEsAceptado());
        dto.setEsRevisado(solcitudModel.getEsRevisado());
        dto.setObservacion(solcitudModel.getObservacion());
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

    public SolicitudModel editDtoTOEntity(SolicitudRequest dto, SolicitudModel model){
        SolicitudModel solicitudModel = new SolicitudModel();
        solicitudModel.setId(model.getId());
        solicitudModel.setExpediente(dto.getExpediente());
        solicitudModel.setEscuela(dto.getEscuela());
        solicitudModel.setFacultad(dto.getFacultad());
        solicitudModel.setTipoSolicitud(dto.getTipoSolicitud());
        solicitudModel.setComentario(dto.getComentario());
        solicitudModel.setEsAceptado(model.getEsAceptado());
        solicitudModel.setEsRevisado(model.getEsRevisado());
        solicitudModel.setObservacion(model.getObservacion());
        return solicitudModel;
    }
}
