import { Module,forwardRef } from '@nestjs/common';
import { ConfigService } from '@nestjs/config';
import { ClientProxyFactory, Transport } from '@nestjs/microservices';

import { AuthModule } from 'src/Auth/auth.module';
import { DocenteController } from './docente.controller';
import { DocenteService } from './docente.service';
import { FacultadModule } from 'src/Facultad/facultad.module';

@Module({
  imports:[forwardRef(() => AuthModule), FacultadModule],
  controllers: [DocenteController],
  providers: [
              DocenteService,
              {
                provide: 'DOCENTE_SERVICE_TRANSPORT',
                useFactory: (configService: ConfigService) => {
                  const escuela_queue=configService.get<string>('QUEUE_DOCENTE')
                  const host = configService.get<string>('TRANSPORT_HOST');
                  const port = parseInt(configService.get<string>('TRANSPORT_PORT'));
          
                  return ClientProxyFactory.create({
                    transport: Transport.RMQ,
                    options: {
                      urls: [`amqp://${host}:${port}`],
                      queue: escuela_queue,
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
    DocenteService
  ]
})
export class DocenteModule {}
