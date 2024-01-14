import { Module,forwardRef } from '@nestjs/common';
import { ConfigService } from '@nestjs/config';
import { ClientProxyFactory, Transport } from '@nestjs/microservices';
import { AuthModule } from 'src/Auth/auth.module';
import { SesionService } from './sesion.service';
import { SesionController } from './sesion.controller';
import { FacultadModule } from 'src/Facultad/facultad.module';
import { SolicitudModule } from 'src/Solicitud/solicitud.module';

@Module({
  imports:[forwardRef(() => AuthModule), FacultadModule, SolicitudModule ],
  controllers: [SesionController],
  providers: [
              SesionService,
              {
                provide: 'SESION_SERVICE_TRANSPORT',
                useFactory: (configService: ConfigService) => {
                  const sesion_queue=configService.get<string>('QUEUE_SESION')
                  const host = configService.get<string>('TRANSPORT_HOST');
                  const port = parseInt(configService.get<string>('TRANSPORT_PORT'));
          
                  return ClientProxyFactory.create({
                    transport: Transport.RMQ,
                    options: {
                      urls: [`amqp://${host}:${port}`],
                      queue: sesion_queue,
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
    SesionService
  ]
})
export class SesionModule {}
