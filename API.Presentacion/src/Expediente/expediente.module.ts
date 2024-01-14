import { Module,forwardRef } from '@nestjs/common';
import { ConfigService } from '@nestjs/config';
import { ClientProxyFactory, Transport } from '@nestjs/microservices';

import { AuthModule } from 'src/Auth/auth.module';
import { FacultadModule } from 'src/Facultad/facultad.module';
import { ExpedienteController } from './expediente.controller';
import { ExpedienteService } from './expediente.service';

@Module({
  imports:[forwardRef(() => AuthModule),FacultadModule ],
  controllers: [ExpedienteController],
  providers: [
              ExpedienteService,
              {
                provide: 'EXPEDIENTE_SERVICE_TRANSPORT',
                useFactory: (configService: ConfigService) => {
                  const expediente_queue=configService.get<string>('QUEUE_EXPEDIENTE')
                  const host = configService.get<string>('TRANSPORT_HOST');
                  const port = parseInt(configService.get<string>('TRANSPORT_PORT'));
          
                  return ClientProxyFactory.create({
                    transport: Transport.RMQ,
                    options: {
                      urls: [`amqp://${host}:${port}`],
                      queue: expediente_queue,
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
    ExpedienteService
  ]
})
export class ExpedienteModule {}
