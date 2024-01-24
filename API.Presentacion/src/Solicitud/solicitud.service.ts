import { Injectable, } from '@nestjs/common';
import { CreateSolicitudRequest } from './dto/create-solicitud.request';
import { UpdateSolicitudRequest } from './dto/update-solicitud.request';
import axios from 'axios';

@Injectable()
export class SolicitudService {
  
  private apiSolicitud = process.env.API_SOLICITUD;
  private rootInternet = "http://";
  private rootApi = "/api/v1";
  private nombre = "/solicitud";

  async findAll(){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiSolicitud}${this.rootApi}${this.nombre}/getAll`)
      return resp.data;
    } catch (error) {
      return error;
    }
  }

  async findOneById(idSolicitud:string){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiSolicitud}${this.rootApi}${this.nombre}/findSolicitudById/${idSolicitud}`)
      return resp.data;
    } catch (error) {
      return error;
    }
  }


  async createSolicitud(createSolicitudRequest:CreateSolicitudRequest){

    try {
      const resp = await axios.post(`${this.rootInternet}${this.apiSolicitud}${this.rootApi}${this.nombre}`,{...createSolicitudRequest})
      return resp.data;
    } catch (error) {
      return error;
    }

    
  }

  async updateSolicitud({idSolicitud,...rest}:UpdateSolicitudRequest){
    
    try {
      const resp = await axios.put(`${this.rootInternet}${this.apiSolicitud}${this.rootApi}${this.nombre}/solicitudUpdate/${idSolicitud}`,{...rest})
      return resp.data;
    } catch (error) {
      return error;
    }
   
  }
  
  async deleteSolicitud(idSolicitud:string){
    try {
      const resp = await axios.delete(`${this.rootInternet}${this.apiSolicitud}${this.rootApi}${this.nombre}/solicitudDelete/${idSolicitud}`)
      return resp.data;
    } catch (error) {
      return error;
    }
  }
  

  
    
}
