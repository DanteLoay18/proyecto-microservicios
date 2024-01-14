import { Module,forwardRef } from '@nestjs/common';
import { ConfigService } from '@nestjs/config';
import { ClientProxyFactory, Transport } from '@nestjs/microservices';

import { AuthModule } from 'src/Auth/auth.module';
import { FacultadModule } from 'src/Facultad/facultad.module';
import { SolicitudService } from './solicitud.service';
import { SolicitudController } from './solicitud.controller';
import { ExpedienteModule } from 'src/Expediente/expediente.module';

@Module({
  imports:[forwardRef(() => AuthModule),FacultadModule ,ExpedienteModule],
  controllers: [SolicitudController],
  providers: [
                SolicitudService,
              {
                provide: 'SOLICITUD_SERVICE_TRANSPORT',
                useFactory: (configService: ConfigService) => {
                  const solicitud_queue=configService.get<string>('QUEUE_SOLICITUD')
                  const host = configService.get<string>('TRANSPORT_HOST');
                  const port = parseInt(configService.get<string>('TRANSPORT_PORT'));
          
                  return ClientProxyFactory.create({
                    transport: Transport.RMQ,
                    options: {
                      urls: [`amqp://${host}:${port}`],
                      queue: solicitud_queue,
                      queueOptions: {
                        durable: false, 
                      }
                    },
                  });
                },
                inject: [ConfigService],
              },
              
            ],
  exports:[
    SolicitudService
  ]
})
export class SolicitudModule {}
