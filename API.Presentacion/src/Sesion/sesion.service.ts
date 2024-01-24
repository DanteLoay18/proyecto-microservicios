import { Injectable, } from '@nestjs/common';
import { CreateSesionRequest } from './dto/create-sesion.request';
import { FindByBusquedaPaginatedRequest } from './dto/find-by-busqueda.request';
import { UpdateSesionRequest } from './dto/update-sesion.request';
import { AgregarSolicitudRequest } from './dto/agregar-solicitud.request';
import axios from 'axios';

@Injectable()
export class SesionService {
  
  private apiSesion = process.env.API_SESION;
  private rootInternet = "http://";
  private rootApi = "/api/v1";
  private nombre = "/sesion";
    
  async findAll(){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiSesion}${this.rootApi}${this.nombre}/getAll`)
      return resp.data;
    } catch (error) {
      return error;
    }
    
  }
    
  async findOneById(idSesion:string){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiSesion}${this.rootApi}${this.nombre}/findSesionById/${idSesion}`)
      return resp.data;
    } catch (error) {
      return error;
    }
  }
 
    async createSesion(createSesionRequest:CreateSesionRequest){
      try {
        const resp = await axios.post(`${this.rootInternet}${this.apiSesion}${this.rootApi}${this.nombre}/crear-sesion`, {...createSesionRequest})
        return resp.data;
      } catch (error) {
        return error;
      }
      
    }

    async updateSesion({idSesion, ...rest}:UpdateSesionRequest){
      try {
        const resp = await axios.put(`${this.rootInternet}${this.apiSesion}${this.rootApi}${this.nombre}/update/${idSesion}`,{...rest})
        return resp.data;
      } catch (error) {
        return error;
      }
    
    }

    async agregarSolicitud(agregarSolicitudRequest:AgregarSolicitudRequest){
      try {
        const resp = await axios.put(`${this.rootInternet}${this.apiSesion}${this.rootApi}${this.nombre}/agregar-solicitudes`,{...agregarSolicitudRequest})
        return resp.data;
      } catch (error) {
        return error;
      }
      
       

      
  
    }
    
}
