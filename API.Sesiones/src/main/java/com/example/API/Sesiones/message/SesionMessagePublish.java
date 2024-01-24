package com.example.API.Sesiones.message;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;

import com.example.API.Sesiones.dto.SolicitudDto;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.kafka.core.KafkaTemplate;

@Component
public class SesionMessagePublish {

    @Value("${spring.kafka.template.default-topic}")
    String topicName;

    // private Logger loLg = LoggerFactory.getLogger(PayMessagePublish.class);

    @Autowired
    KafkaTemplate<Integer, String> kafkaTemplate;

    @Autowired
    ObjectMapper objectMapper;

    public void sendAgregarSolicitudEvent(SolicitudDto solicitudDto) throws JsonProcessingException {

        String value = objectMapper.writeValueAsString(solicitudDto);
        kafkaTemplate.send(topicName, value);
    }
}
