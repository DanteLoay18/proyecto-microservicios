package com.example.API.Sesiones.controller;

import org.springframework.web.bind.annotation.RestController;

import com.example.API.Sesiones.dto.AgregarSolicitudesSesionRequest;
import com.example.API.Sesiones.dto.ApiResponse;
import com.example.API.Sesiones.dto.CreateSesionRequest;
import com.example.API.Sesiones.dto.MiembroComisionResponse;
import com.example.API.Sesiones.dto.SesionResponse;
import com.example.API.Sesiones.dto.SolicitudDto;
import com.example.API.Sesiones.dto.SolicitudResponse;
import com.example.API.Sesiones.mapper.MiembroComisionMapper;
import com.example.API.Sesiones.mapper.SesionMapper;
import com.example.API.Sesiones.mapper.SolicitudesMapper;
import com.example.API.Sesiones.message.SesionMessagePublish;
import com.example.API.Sesiones.model.MiembroComisionModel;
import com.example.API.Sesiones.model.SesionModel;
import com.example.API.Sesiones.model.SolicitudesModel;
import com.example.API.Sesiones.service.IMiembroComisionService;
import com.example.API.Sesiones.service.ISesionService;
import com.example.API.Sesiones.service.ISolicitudesService;

import java.util.List;
import java.util.stream.Collectors;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import com.example.API.Sesiones.constants.MensajeParametrizados;

@RestController
@RequestMapping("/api/v1/sesion")
public class SesionController {
    

    @Autowired
    ISesionService sesionService;

    @Autowired
    IMiembroComisionService miembroComisionService;

    @Autowired
    ISolicitudesService solicitudesService;

    @Autowired
    SesionMapper sesionMapper;

    @Autowired
    MiembroComisionMapper miembroComisionMapper;

    @Autowired
    SolicitudesMapper solicitudesMapper;

    @Autowired
    SesionMessagePublish messageEvent;

    private static final Logger logger = LoggerFactory.getLogger(SesionController.class);
    
    @GetMapping("/getAll")
    public ResponseEntity<ApiResponse<List<SesionResponse>>> getAll(){
        try{
            List<SesionModel> sesiones = sesionService.findAll();

            List<SolicitudResponse> solicitudes = sesiones.stream()
                .flatMap(sesion -> sesion.getSolicitudes().stream()
                    .map(solicitudesMapper::entityToDto))
                .collect(Collectors.toList());
            
            List<SesionResponse> sesionesRequest = sesiones.stream()
                .map(sesion -> {
                    List<SolicitudResponse> solicitudesDeSesion = solicitudes.stream()
                        .filter(solicitud -> solicitud.getIdSesion().equals(sesion.getId()))
                        .collect(Collectors.toList());
            
                    return sesionMapper.entityToDto(sesion, solicitudesDeSesion);
                })
                .collect(Collectors.toList());

            return ResponseEntity.ok(new ApiResponse<>(HttpStatus.OK.value(),"", sesionesRequest));
        }catch(Exception ex){
            logger.error(MensajeParametrizados.MENSAJE_ERROR, ex);
            return ResponseEntity.status(HttpStatus.OK)
            .body(new ApiResponse<>(HttpStatus.INTERNAL_SERVER_ERROR.value(),
                "Error al procesar la solicitud", null));
        }
    }

    @PostMapping("/crear-sesion")
    public ResponseEntity<ApiResponse<?>> crearSesion(@RequestBody CreateSesionRequest createSesionRequest){
        try{
            MiembroComisionModel miembroComisionModel = miembroComisionMapper.createRequestToEntity(createSesionRequest);

            MiembroComisionModel miembroComisionCreada = miembroComisionService.add(miembroComisionModel);   

            SesionModel sesionModel = sesionMapper.createRequestToEntity(createSesionRequest, miembroComisionCreada);

            SesionModel sesionCreada = sesionService.add(sesionModel);

            logger.info(MensajeParametrizados.MENSAJE_CREAR_EXITOSO);

            return ResponseEntity.ok(new ApiResponse<>(HttpStatus.OK.value(),MensajeParametrizados.MENSAJE_CREAR_EXITOSO, sesionCreada.getId()));
        }catch(Exception ex){
            logger.error(MensajeParametrizados.MENSAJE_ERROR, ex);
            return ResponseEntity.status(HttpStatus.OK)
            .body(new ApiResponse<>(HttpStatus.INTERNAL_SERVER_ERROR.value(),
            MensajeParametrizados.MENSAJE_ERROR_INTERNO_SERVIDOR, null));
        }
    }

    @PutMapping("/agregar-solicitudes")
    public ResponseEntity<ApiResponse<?>> agregarSolicitudes(@RequestBody AgregarSolicitudesSesionRequest agregarSolicitudesSesionesRequest){
        try{
            SesionModel sesionEncontrada = this.sesionService.findById(agregarSolicitudesSesionesRequest.getIdSesion());

            if(sesionEncontrada == null){
                return ResponseEntity.ok(new ApiResponse<>(HttpStatus.NOT_FOUND.value(),MensajeParametrizados.MENSAJE_ERROR_NO_ENCONTRADO,null ));
            }

            SolicitudesModel solicitudEntity = solicitudesMapper.agregarSolicitudesRequestToEntity(agregarSolicitudesSesionesRequest, sesionEncontrada);

            SolicitudesModel solicitudCreada = solicitudesService.add(solicitudEntity);  
            
            SolicitudDto solicitudDto = solicitudesMapper.agregarSolicitudesRequestToEntity(agregarSolicitudesSesionesRequest);

            messageEvent.sendAgregarSolicitudEvent(solicitudDto);

            logger.info(MensajeParametrizados.MENSAJE_CREAR_EXITOSO);

            return ResponseEntity.ok(new ApiResponse<>(HttpStatus.OK.value(),MensajeParametrizados.MENSAJE_CREAR_EXITOSO, solicitudCreada.getId() ));
        }catch(Exception ex){
            logger.error(MensajeParametrizados.MENSAJE_ERROR, ex);
            return ResponseEntity.status(HttpStatus.OK)
            .body(new ApiResponse<>(HttpStatus.INTERNAL_SERVER_ERROR.value(),
            MensajeParametrizados.MENSAJE_ERROR_INTERNO_SERVIDOR, null));
        }
    }
    
    @PutMapping("/update/{id}")
    public ResponseEntity<ApiResponse<SesionResponse>> updateSesion(@PathVariable Integer id, @RequestBody CreateSesionRequest updateSesionRequest) {
        try {
            SesionModel existingSesion = sesionService.findById(id);

            if (existingSesion == null) {
                return ResponseEntity.status(HttpStatus.NOT_FOUND)
                        .body(new ApiResponse<>(HttpStatus.NOT_FOUND.value(),
                                MensajeParametrizados.MENSAJE_ERROR_NO_ENCONTRADO, null));
            }

            // Actualizar la sesión con los datos proporcionados
            existingSesion = sesionMapper.updateSesionFromRequest(existingSesion, updateSesionRequest);
            sesionService.update(existingSesion);

            // Mapear la sesión actualizada a un DTO de respuesta
            SesionResponse sesionResponse = sesionMapper.entityToDto(existingSesion, null);

            return ResponseEntity.ok(new ApiResponse<>(HttpStatus.OK.value(),
                    MensajeParametrizados.MENSAJE_MODIFICAR_EXITOSO, sesionResponse));
        } catch (Exception ex) {
            logger.error(MensajeParametrizados.MENSAJE_ERROR, ex);
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR)
                    .body(new ApiResponse<>(HttpStatus.INTERNAL_SERVER_ERROR.value(),
                            MensajeParametrizados.MENSAJE_ERROR_INTERNO_SERVIDOR, null));
        }
    }
}
