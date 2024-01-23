package com.example.API.Solicitudes.controller;
import org.springframework.web.bind.annotation.RestController;

import com.example.API.Solicitudes.dto.SolicitudRequest;
import com.example.API.Solicitudes.model.SolicitudModel;
import com.example.API.Solicitudes.service.ISolicitudService;


import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;


@RestController
@RequestMapping("/api/v1/solicitud")
public class SolicitudController {
    
    @Autowired
    ISolicitudService solicitudService;

    private static final Logger logger = LoggerFactory.getLogger(SolicitudController.class);
    
    @PostMapping
    public ResponseEntity<?> register(@RequestBody SolicitudRequest request) throws Exception {

            SolicitudModel solicitudModel = new SolicitudModel();
            solicitudModel.setExpediente(request.getExpediente());
            solicitudModel.setEscuela(request.getEscuela());
            solicitudModel.setFacultad(request.getFacultad());
            solicitudModel.setTipoSolicitud(request.getTipoSolicitud());
            solicitudModel.setComentario(request.getComentario());

            solicitudService.add(solicitudModel);
            logger.error("MensajesParametrizados.MENSAJE_ERROR_AUTENTICACION, e.getMessage()");
            return ResponseEntity.status(HttpStatus.CREATED).body(solicitudModel);
    }
}
