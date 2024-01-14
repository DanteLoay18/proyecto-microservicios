import { Injectable,Inject, BadRequestException } from '@nestjs/common';
import { ClientProxy } from '@nestjs/microservices';

import { map, tap, lastValueFrom,} from 'rxjs';
import { FacultadService } from 'src/Facultad/facultad.service';
import { v4 } from 'uuid';
import { CreateSesionRequest } from './dto/create-sesion.request';
import { FindByBusquedaPaginatedRequest } from './dto/find-by-busqueda.request';
import { UpdateSesionRequest } from './dto/update-sesion.request';
import { AgregarSolicitudRequest } from './dto/agregar-solicitud.request';
import { SolicitudService } from 'src/Solicitud/solicitud.service';


@Injectable()
export class SesionService {
  
  constructor(
    @Inject('SESION_SERVICE_TRANSPORT') private clienteUser: ClientProxy,
    private facultadService:FacultadService,
    private solicitudService:SolicitudService
    ) {}
    
    async findUltimoIteracionMiembroComision(idUsuario:string){
      
    }

    async findAllPaginated(page:number, pageSize:number, idUsuario:string){
  
      
    }
  
   
    
    findOneById(idSesion:string){
      
    }

    async findSolicitudesBySesion(idSesion:string, page:number, pageSize:number){
     
    }

    async findByBusqueda(findByBusquedaPaginatedRequest:FindByBusquedaPaginatedRequest, idUsuario:string){
  
      
    }
  
 
    async createSesion(createSesionRequest:CreateSesionRequest, idUsuario:string){

      
    }

    async updateSesion(updateSesionRequest:UpdateSesionRequest, idUsuario:string){

     
  
    }

    async agregarSolicitud(agregarSolicitudRequest:AgregarSolicitudRequest, idUsuario:string){

      
       

      
  
    }
    
}
