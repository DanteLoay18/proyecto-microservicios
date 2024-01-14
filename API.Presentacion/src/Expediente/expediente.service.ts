import { Injectable,Inject, BadRequestException } from '@nestjs/common';
import { ClientProxy } from '@nestjs/microservices';

import { map, tap, lastValueFrom, mergeMap, } from 'rxjs';
import { UsuarioService } from 'src/Auth/usuario.service';
import { FacultadService } from 'src/Facultad/facultad.service';
import { sistemaConstants } from 'src/Shared/constants/sistema.constants';
import { v4 } from 'uuid';
import { CreateExpedienteRequest } from './dto/create-expediente.request';
import { tipoDescripcion } from './enums/tipoExpediente.enums';
import { FindByBusquedaPaginatedRequest } from './dto/find-by-busqueda.request';
import { UpdateExpedienteRequest } from './dto/update-expediente.request';
import { ValidarExpedienteRequest } from './dto/validar-expediente.request';
@Injectable()
export class ExpedienteService {
  
  constructor(
    @Inject('EXPEDIENTE_SERVICE_TRANSPORT') private clienteUser: ClientProxy,
    private readonly usuarioService:UsuarioService,
    private readonly facultadService:FacultadService

    ) {}
  
  async findAllPaginated(page:number, pageSize:number, rolUsuario:string, idUsuario:string){
   
  }

 
  
  findOneById(idDocente:string){
    return this.clienteUser.send({cmd:'findOne_expediente'},idDocente).pipe(
                                                                            tap(({success, message}) =>{ if(!success) throw new BadRequestException(message)} ),
                                                                            map(({value, ...rest})=> {
                                                                                const buffer = Buffer.from(value._id);
                                                                                const uuid = v4({ random: buffer });
                                                                              
                                                                                return {
                                                                                  ...rest,
                                                                                  value:{
                                                                                    ...value,
                                                                                    _id:uuid
                                                                                  }
                                                                                }
                                                                              
                                                                            }),
                                                                            );
  }

  async findByBusqueda(findByBusquedaPaginatedRequest:FindByBusquedaPaginatedRequest,rolUsuario:string, idUsuario:string){

   
  }

  async createExpediente(createExpedienteRequest:CreateExpedienteRequest,rolUsuario:string, idUsuario:string){

  }

  async updateExpediente(updateExpedienteRequest:UpdateExpedienteRequest,rolUsuario:string, idUsuario:string){

   
  }

  async validarExpediente(validarExpedienteRequest:ValidarExpedienteRequest, idUsuario:string){
  
    
  }

  async eliminarExpediente(idExpediente:string,rolUsuario:string, idUsuario:string){
   
  }
 
    
}
