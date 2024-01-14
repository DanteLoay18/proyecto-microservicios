import { Injectable,Inject, BadRequestException } from '@nestjs/common';
import { AsignarEncargadoRequest} from './dto/asignar-encargado.request';
import { lastValueFrom, map, mergeMap, tap } from 'rxjs';
import { v4 } from 'uuid';
import {sistemaConstants} from 'src/Shared/constants/sistema.constants'
import { EliminarEncargadoRequest } from './dto/eliminar-encargado.request';
import {ajax} from 'rxjs/ajax';
import axios from 'axios';

@Injectable()
export class FacultadService {
  
  private apiFacultad = process.env.API_FACULTAD;
  private rootInternet = "http://";
  private rootApi = "/api/v1";
  private nombreFacultad = "/facultad";

  async findAllPaginated(page:number, pageSize:number){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiFacultad}${this.rootApi}${this.nombreFacultad}?Page=${page}&PageSize=${pageSize}`)
      return resp.data;
    } catch (error) {
      return error;
    }
    
  }
  async findAllFacultades(){

    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiFacultad}${this.rootApi}${this.nombreFacultad}/findAllFacultades`)
      return resp.data;
    } catch (error) {
      return error;
    }
   
    
  }
  
  async findOneById(idFacultad:string){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiFacultad}${this.rootApi}${this.nombreFacultad}/${idFacultad}`)
      return resp.data;
    } catch (error) {
      return error;
    }
  }

  async findEscuelasByFacultad(idFacultad:string){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiFacultad}${this.rootApi}${this.nombreFacultad}/findEscuelasByFacultad/${idFacultad}`)
      return resp.data;
    } catch (error) {
      return error;
    }
  }


  async asignarEncargadoFacultad( idUsuario:string, {idEncargado, idFacultad}:AsignarEncargadoRequest){

      try {
        const resp = await axios.put(`${this.rootInternet}${this.apiFacultad}${this.rootApi}${this.nombreFacultad}/asignarEncargado`,{idUsuario, idEncargado, idFacultad})
        return resp.data;
      } catch (error) {
        return error;
      }
  }

  async quitarEncargadoFacultad({idFacultad}:EliminarEncargadoRequest ,idUsuario:string){

    try {
      const resp = await axios.put(`${this.rootInternet}${this.apiFacultad}${this.rootApi}${this.nombreFacultad}/eliminarEncargado`,{idUsuario, idFacultad})
      return resp.data;
    } catch (error) {
      return error;
    }
  }
  
}
