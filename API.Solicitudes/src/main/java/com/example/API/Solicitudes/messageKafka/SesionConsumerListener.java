package com.example.API.Solicitudes.messageKafka;

import org.apache.kafka.clients.consumer.ConsumerRecord;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.kafka.annotation.KafkaListener;

import com.example.API.Solicitudes.dto.SolicitudRequestKafka;
import com.example.API.Solicitudes.model.SolicitudModel;
import com.example.API.Solicitudes.service.ISolicitudService;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.stereotype.Component;

@Component
public class SesionConsumerListener {

     private Logger log = LoggerFactory.getLogger(SesionConsumerListener.class);

    @Autowired
    ISolicitudService service;

    @KafkaListener(topics = "${spring.kafka.template.default-topic}")
    public void OnMessage(ConsumerRecord<Integer, String> consumerRecord)
            throws JsonMappingException, JsonProcessingException {
        log.info("****************************************************************");
        log.info("ConsumerRecord : {}", consumerRecord.value());

        ObjectMapper objectMapper = new ObjectMapper();
        String jsonMessage = consumerRecord.value();
        SolicitudRequestKafka data = objectMapper.readValue(jsonMessage, SolicitudRequestKafka.class);

        SolicitudModel solicitud = service.findById(data.getId());

        solicitud.setEsAceptado(true);
        solicitud.setEsRevisado(true);

        // log.info("Register Transaction {} ", data.getId_operation());
        service.update(solicitud);

        log.info("****************************************************************");
    }
}
