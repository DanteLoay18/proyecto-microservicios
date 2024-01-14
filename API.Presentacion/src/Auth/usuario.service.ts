import { Injectable,Inject, BadRequestException } from '@nestjs/common';
import { ClientProxy } from '@nestjs/microservices';

import { map, tap, lastValueFrom, mergeMap } from 'rxjs';
import { sistemaConstants } from 'src/Shared/constants/sistema.constants';
import { v4 } from 'uuid';
@Injectable()
export class UsuarioService {
  
  constructor(
    @Inject('USUARIO_SERVICE_TRANSPORT') private clienteUser: ClientProxy,

    ) {} 
  
  findOneById(idUsuario:string){
    return this.clienteUser.send({cmd:'findOne_usuario'},idUsuario).pipe(
                                                                            tap((error) =>{ if(error?.error) throw new BadRequestException(error.message)} ),
                                                                            map(({_id,email, nombres, dni, primerApellido, segundoApellido, avatarText, permisos,isDefaultPassword})=> {return {_id,email,dni, nombres, primerApellido, segundoApellido, avatarText, permisos,isDefaultPassword}}),
                                                                            map(({_id, ...rest})=> {
                                                                            
                                                                                const buffer = Buffer.from(_id);
                                                                                const uuid = v4({ random: buffer });
                                                                            
                                                                                return {
                                                                                _id:uuid,
                                                                                ...rest
                                                                                }
                                                                            
                                                                            })
                                                                        );
  }

 
    
}
