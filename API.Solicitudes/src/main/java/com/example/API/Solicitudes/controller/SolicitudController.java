package com.example.API.Solicitudes.controller;
import org.springframework.web.bind.annotation.RestController;

import com.example.API.Solicitudes.Mapper.SolcitudMapper;
import com.example.API.Solicitudes.constantes.MensajesParametrizados;
import com.example.API.Solicitudes.dto.ApiResponse;
import com.example.API.Solicitudes.dto.SolicitudRequest;
import com.example.API.Solicitudes.model.SolicitudModel;
import com.example.API.Solicitudes.service.ISolicitudService;

import java.util.List;
import java.util.stream.Collectors;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;


@RestController
@RequestMapping("/api/v1/solicitud")
public class SolicitudController {
    
    @Autowired
    ISolicitudService solicitudService;

    @Autowired
    SolcitudMapper solicitudMapper;

    private static final Logger logger = LoggerFactory.getLogger(SolicitudController.class);
    



    @GetMapping("/getAll")
    public ResponseEntity<ApiResponse<List<SolicitudRequest>>> getAll(){
        try{
            List<SolicitudModel> usuarios = solicitudService.findAll();
            List<SolicitudRequest> authRequests = usuarios.stream()
            .map(solicitudMapper::entityToDto)
            .collect(Collectors.toList());
            return ResponseEntity.ok(new ApiResponse<>(HttpStatus.OK.value(),
                "Consulta de listado de Usuario exitosa", authRequests));
        }catch(Exception ex){
            logger.error(MensajesParametrizados.MENSAJE_ERROR, ex);
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR)
            .body(new ApiResponse<>(HttpStatus.INTERNAL_SERVER_ERROR.value(),
                "Error al procesar la solicitud", null));
        }
    }

    @PostMapping
    public ResponseEntity<?> register(@RequestBody SolicitudRequest request) throws Exception {
        try{
            SolicitudModel solicitudModel = solicitudMapper.dtoTOEntity(request);

            solicitudService.add(solicitudModel);
            logger.info(MensajesParametrizados.MENSAJE_CREAR_SOLICITUD_EXITOSO);
            return ResponseEntity.status(HttpStatus.CREATED).body(solicitudModel);
        }catch(Exception ex){
            logger.error(MensajesParametrizados.MENSAJE_CREAR_PACIENTE_NOEXITOSO, ex);
            return ResponseEntity.status(HttpStatus.OK).body(null);
        }
    }
}
