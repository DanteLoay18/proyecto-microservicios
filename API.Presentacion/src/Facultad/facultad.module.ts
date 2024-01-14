import { Module,forwardRef,  } from '@nestjs/common';
import { ConfigService } from '@nestjs/config';
import { ClientProxyFactory, Transport } from '@nestjs/microservices';

import { AuthModule } from 'src/Auth/auth.module';
import { FacultadController } from './facultad.controller';
import { FacultadService } from './facultad.service';

@Module({
  imports:[forwardRef(() => AuthModule),],
  controllers: [FacultadController],
  providers: [
              FacultadService,
             
            ],
  exports:[
    FacultadService
  ]
})
export class FacultadModule {}
