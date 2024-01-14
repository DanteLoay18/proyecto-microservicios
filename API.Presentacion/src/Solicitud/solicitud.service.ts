import { Injectable,Inject, BadRequestException } from '@nestjs/common';
import { ClientProxy } from '@nestjs/microservices';

import { map, tap,lastValueFrom, mergeMap, } from 'rxjs';
import { UsuarioService } from 'src/Auth/usuario.service';
import { FacultadService } from 'src/Facultad/facultad.service';
import { v4 } from 'uuid';
import { tipoDescripcion } from './enums/tipoExpediente.enums';
import { S3 } from 'aws-sdk';
import { CreateSolicitudRequest } from './dto/create-solicitud.request';
import { UpdateSolicitudRequest } from './dto/update-solicitud.request';
import { tipoSolicitud } from './data/tipoSolicitud';
import { CambiarEstadoRequest } from './dto/cambiar-estado-solicitud.request';
import { ExpedienteService } from 'src/Expediente/expediente.service';

@Injectable()
export class SolicitudService {
  bucketName= process.env.S3_BUCKET_NAME;
  s3= new S3({
    accessKeyId:process.env.S3_ACCESS_KEY,
    secretAccessKey:process.env.S3_SECRET_ACCESS_KEY,
    region:"us-east-1"
  })

  constructor(
    @Inject('SOLICITUD_SERVICE_TRANSPORT') private clienteUser: ClientProxy,
    private readonly usuarioService:UsuarioService,
    private readonly facultadService:FacultadService,
    private readonly expedienteService:ExpedienteService

    ) {}
  
  async findAllPaginatedNoRevisado(page:number, pageSize:number, idUsuario:string){
    
  }

  async findAllPaginated(page:number, pageSize:number,idExpediente:string, idUsuario:string){

    
  }

 
  
  findOneByIdAndExpediente(idDocente:string){
    
  }

  findOneByIdSolicitudExpediente(idSolicitud:string){
    
  }

  findOneById(idSolicitud:string){
   
  }

  filtrarTipoSolicitud(tipoExpediente:number){
    return tipoSolicitud.filter((tipo)=>tipo.tipoExpediente===tipoExpediente);
  }


  async createSolicitud(createSolicitudRequest:CreateSolicitudRequest, idUsuario:string){

    

    
  }

  async updateSolicitud(updateSolicitudRequest:UpdateSolicitudRequest, idUsuario:string){

   
  }
  

  async cambiarEstadoSolicitud(cambiarEstadoRequest:CambiarEstadoRequest, idUsuario:string){

  }
  async deleteSolicitud(idSolicitud:string, idUsuario:string){
   
  }
  

  
    
}
