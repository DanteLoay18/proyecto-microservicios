import { Module } from '@nestjs/common';
import { SharedModule } from './Shared/shared.module';
import { AuthModule } from './Auth/auth.module';
import { FacultadModule } from './Facultad/facultad.module';
import { DocenteModule } from './Docente/docente.module';
import { ExpedienteModule } from './Expediente/expediente.module';
import { SolicitudModule } from './Solicitud/solicitud.module';
import { SesionModule } from './Sesion/sesion.module';

@Module({
  imports: [SharedModule,
            FacultadModule,
            DocenteModule,
            ExpedienteModule,
            SolicitudModule,
            SesionModule,
            AuthModule],
  controllers: [],
  providers: [],
})
export class AppModule {}
