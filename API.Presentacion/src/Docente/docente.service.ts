import { Injectable,Inject, BadRequestException } from '@nestjs/common';
import { ClientProxy } from '@nestjs/microservices';

import { map, tap, lastValueFrom, mergeMap } from 'rxjs';
import { v4 } from 'uuid';
import { CreateDocenteRequest } from './dto/create-docente.request';
import { FacultadService } from 'src/Facultad/facultad.service';
import { UpdateDocenteRequest } from './dto/update-docente.request';
import { FindByBusquedaPaginatedRequest } from './dto/find-by-busqueda';
import { ModificarEstadoRequest } from './dto/modificar-estado.request';
import { FindByEscuelaRequest } from './dto/find-by-escuela.request';

@Injectable()
export class DocenteService {
  
  constructor(
    @Inject('DOCENTE_SERVICE_TRANSPORT') private clienteUser: ClientProxy,
    private readonly facultadService:FacultadService
    ) {}
  
  async findAllPaginated(page:number, pageSize:number, idUsuario:string){

    
  }

  async findByBusqueda(findByBusquedaPaginatedRequest:FindByBusquedaPaginatedRequest, idUsuario:string){

    
  }
  
  findByEscuela(findByEscuelaRequest:FindByEscuelaRequest){
    return this.clienteUser.send({cmd:'findByEscuela_docente'},{...findByEscuelaRequest}).pipe(
                                                                                                                  map(({value, ...rest})=> {
                                                                                                                    const newItems= value.map(({_id, ...rest})=> {
                                                                                                                      const buffer = Buffer.from(_id);
                                                                                                                      const uuid = v4({ random: buffer });
                                                                                                                    
                                                                                                                      return {
                                                                                                                        _id:uuid,
                                                                                                                        ...rest
                                                                                                                      }
                                                                                                                    })
                                                                                                                    return {
                                                                                                                      ...rest,
                                                                                                                      value:newItems,

                                                                                                                    }
                                                                                                                  }),
                                                                                                                );
  }

  async findByFacultad(idUsuario:string){

   
  }


  findOneById(idDocente:string){
    
  }

  async createDocente(createDocenteRequest:CreateDocenteRequest, usuarioCreacion:string){

    
  }

  async updateDocente(idDocente:string,updateDocenteRequest:UpdateDocenteRequest, usuarioModificacion:string){

      
  }

  async modificarEstado(idDocente:string,modificarEstadoRequest:ModificarEstadoRequest, usuarioModificacion:string){
      return this.clienteUser.send({cmd:'modificar_estado_docente'},{idUsuario:usuarioModificacion, ...modificarEstadoRequest, idDocente}).pipe(
                                                                        tap(({success, message}) =>{ if(!success) throw new BadRequestException(message)} ),                                         
                                                                  );
  }
    
}
