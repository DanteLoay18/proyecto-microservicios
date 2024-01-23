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
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiExpediente}${this.rootApi}${this.nombreExpediente}?Page=${page}&PageSize=${pageSize}&idUsuario=${idUsuario}`);
      return resp.data;
    } catch (error) {
      throw new BadRequestException(error.message);
    }  
  }

  async findByBusqueda(findByBusquedaPaginatedRequest:FindByBusquedaPaginatedRequest, idUsuario:string){
    try {
      const resp = await this.clienteUser.send({ cmd: 'find_by_busqueda' }, { request: findByBusquedaPaginatedRequest, idUsuario }).pipe(
        tap(({ success, message }) => { if (!success) throw new BadRequestException(message) }),
        map(({ value, ...rest }) => ({
          ...rest,
          value
        })),
      ).toPromise();

      return resp.value;
    } catch (error) {
      throw new BadRequestException(error.message);
    }
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
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiExpediente}${this.rootApi}${this.nombreExpediente}/findByFacultad?idUsuario=${idUsuario}`);
      return resp.data;
    } catch (error) {
      throw new BadRequestException(error.message);
    }
  }


  findOneById(idDocente:string){
    try {
      const resp = await this.clienteUser.send({ cmd: 'findOne_docente' }, idDocente).pipe(
        tap(({ success, message }) => { if (!success) throw new BadRequestException(message) }),
        map(({ value, ...rest }) => ({
          ...rest,
          value
        })),
      ).toPromise();

      return resp.value;
    } catch (error) {
      throw new BadRequestException(error.message);
    }
  }

  async createDocente(createDocenteRequest:CreateDocenteRequest, usuarioCreacion:string){
    try {
      const resp = await this.clienteUser.send({ cmd: 'create_docente' }, { request: createDocenteRequest, usuarioCreacion }).pipe(
        tap(({ success, message }) => { if (!success) throw new BadRequestException(message) }),
        map(({ value, ...rest }) => ({
          ...rest,
          value
        })),
      ).toPromise();

      return resp.value;
    } catch (error) {
      throw new BadRequestException(error.message);
    }    
  }

  async updateDocente(idDocente:string,updateDocenteRequest:UpdateDocenteRequest, usuarioModificacion:string){
    try {
      const resp = await this.clienteUser.send({ cmd: 'update_docente' }, { idDocente, request: updateDocenteRequest, usuarioModificacion }).pipe(
        tap(({ success, message }) => { if (!success) throw new BadRequestException(message) }),
        map(({ value, ...rest }) => ({
          ...rest,
          value
        })),
      ).toPromise();

      return resp.value;
    } catch (error) {
      throw new BadRequestException(error.message);
    }      
  }

  async modificarEstado(idDocente:string,modificarEstadoRequest:ModificarEstadoRequest, usuarioModificacion:string){
      return this.clienteUser.send({cmd:'modificar_estado_docente'},{idUsuario:usuarioModificacion, ...modificarEstadoRequest, idDocente}).pipe(
                                                                        tap(({success, message}) =>{ if(!success) throw new BadRequestException(message)} ),                                         
                                                                  );
  }
    
}
