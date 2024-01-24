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
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
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
    public ResponseEntity<ApiResponse<List<SolicitudRequest>>> getAll() {
        try {
            List<SolicitudModel> usuarios = solicitudService.findAll();
            List<SolicitudRequest> authRequests = usuarios.stream()
                    .map(solicitudMapper::entityToDto)
                    .collect(Collectors.toList());
            return ResponseEntity.ok(new ApiResponse<>(HttpStatus.OK.value(),
                    "", authRequests));
        } catch (Exception ex) {
            logger.error(MensajesParametrizados.MENSAJE_ERROR_INTERNO_SERVIDOR, ex);
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR)
                    .body(new ApiResponse<>(HttpStatus.INTERNAL_SERVER_ERROR.value(),
                            MensajesParametrizados.MENSAJE_ERROR_INTERNO_SERVIDOR, null));
        }
    }

    @PostMapping
    public ResponseEntity<?> register(@RequestBody SolicitudRequest request) throws Exception {
        try {
            SolicitudModel solicitudModel = solicitudMapper.dtoTOEntity(request);
            solicitudService.add(solicitudModel);
            logger.info(MensajesParametrizados.MENSAJE_CREAR_SOLICITUD_EXITOSO);
            return ResponseEntity.status(HttpStatus.CREATED).body(solicitudModel);
        } catch (Exception ex) {
            logger.error(MensajesParametrizados.MENSAJE_ERROR_INTERNO_SERVIDOR, ex);
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(null);
        }
    }

    @GetMapping("/findSolicitudById/{id}")
    public ResponseEntity<ApiResponse<SolicitudRequest>> findSolicitudById(@PathVariable int id) {
        try {
            SolicitudModel solicitud = solicitudService.findById(id);
            if (solicitud != null) {
                SolicitudRequest solicitudRequest = solicitudMapper.entityToDto(solicitud);
                return ResponseEntity.ok(new ApiResponse<>(HttpStatus.OK.value(),
                        MensajesParametrizados.MENSAJE_PACIENTE_LISTADOID, solicitudRequest));
            } else {
                return ResponseEntity.status(HttpStatus.NOT_FOUND)
                        .body(new ApiResponse<>(HttpStatus.NOT_FOUND.value(),
                                MensajesParametrizados.usuarioNoEncontradoPorId(id), null));
            }
        } catch (Exception ex) {
            logger.error(MensajesParametrizados.MENSAJE_ERROR, ex);
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR)
                    .body(new ApiResponse<>(HttpStatus.INTERNAL_SERVER_ERROR.value(),
                            MensajesParametrizados.MENSAJE_ERROR_INTERNO_SERVIDOR, null));
        }
    }

    @PutMapping("/solicitudUpdate/{id}")
    public ResponseEntity<ApiResponse<SolicitudRequest>> solicitudUpdate(@PathVariable int id,
            @RequestBody SolicitudRequest request) {
        try {
            SolicitudModel existingSolicitud = solicitudService.findById(id);
            if (existingSolicitud != null) {
                existingSolicitud = solicitudMapper.dtoTOEntity(request);
                solicitudService.update(existingSolicitud);
                SolicitudRequest solicitudRequest = solicitudMapper.entityToDto(existingSolicitud);
                return ResponseEntity.ok(new ApiResponse<>(HttpStatus.OK.value(),
                        MensajesParametrizados.MENSAJE_PACIENTE_EDITADO_EXITOSO, solicitudRequest));
            } else {
                return ResponseEntity.status(HttpStatus.NOT_FOUND)
                        .body(new ApiResponse<>(HttpStatus.NOT_FOUND.value(),
                                MensajesParametrizados.usuarioNoEncontradoPorId(id), null));
            }
        } catch (Exception ex) {
            logger.error(MensajesParametrizados.MENSAJE_ERROR, ex);
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR)
                    .body(new ApiResponse<>(HttpStatus.INTERNAL_SERVER_ERROR.value(),
                            MensajesParametrizados.MENSAJE_ERROR_INTERNO_SERVIDOR, null));
        }
    }

    @DeleteMapping("/solicitudDelete/{id}")
    public ResponseEntity<ApiResponse<Void>> solicitudDelete(@PathVariable int id) {
        try {
            SolicitudModel existingSolicitud = solicitudService.findById(id);
            if (existingSolicitud != null) {
                solicitudService.delete(id);
                return ResponseEntity.ok(new ApiResponse<>(HttpStatus.OK.value(),
                        MensajesParametrizados.MENSAJE_ELIMINAR_PACIENTE_EXITOSO, null));
            } else {
                return ResponseEntity.status(HttpStatus.NOT_FOUND)
                        .body(new ApiResponse<>(HttpStatus.NOT_FOUND.value(),
                                MensajesParametrizados.usuarioNoEncontradoPorId(id), null));
            }
        } catch (Exception ex) {
            logger.error(MensajesParametrizados.MENSAJE_ERROR, ex);
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR)
                    .body(new ApiResponse<>(HttpStatus.INTERNAL_SERVER_ERROR.value(),
                            MensajesParametrizados.MENSAJE_ERROR_INTERNO_SERVIDOR, null));
        }
    }

}
