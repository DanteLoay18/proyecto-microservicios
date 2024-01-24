import { Injectable, } from '@nestjs/common';
import { CreateExpedienteRequest } from './dto/create-expediente.request';
import { FindByBusquedaPaginatedRequest } from './dto/find-by-busqueda.request';
import { UpdateExpedienteRequest } from './dto/update-expediente.request';
import axios from 'axios';

@Injectable()
export class ExpedienteService {
  
  private apiExpediente = process.env.API_EXPEDIENTE;
  private rootInternet = "http://";
  private rootApi = "/api/v1";
  private nombre = "/expediente";


  async findAllPaginated(page:number, pageSize:number){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiExpediente}${this.rootApi}${this.nombre}/findAllExpedientes?Page=${page}&PageSize=${pageSize}`)
      return resp.data;
    } catch (error) {
      return error;
    }
  }

 
  
  async findOneById(idExpediente:string){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiExpediente}${this.rootApi}${this.nombre}/findExpedienteById/${idExpediente}`)
      return resp.data;
    } catch (error) {
      return error;
    }
  }

  async findExpedienteByBusqueda({page,pageSize,escuela,facultad,numeroExpediente,tipo}:FindByBusquedaPaginatedRequest){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiExpediente}${this.rootApi}${this.nombre}/findExpedientesByBusqueda?Page=${page}&PageSize=${pageSize}&Tipo=${tipo}&Escuela=${escuela}&Facultad=${facultad}&NumeroDeExpediente=${numeroExpediente}`)
      return resp.data;
    } catch (error) {
      return error;
    }
  }

  async createExpediente( idUsuario:string, {tipo, numeroExpediente, escuela, facultad, estudiantes,}:CreateExpedienteRequest){

    try {
      const resp = await axios.post(`${this.rootInternet}${this.apiExpediente}${this.rootApi}${this.nombre}/createExpediente`,{idUsuario, tipo, numeroExpediente, escuela, facultad, estudiantes})
      return resp.data;
    } catch (error) {
      return error;
    }
 }

 async updateExpediente( idUsuario:string, {tipo, numeroExpediente, escuela, facultad, estudiantes,idExpediente}:UpdateExpedienteRequest){

    try {
      const resp = await axios.put(`${this.rootInternet}${this.apiExpediente}${this.rootApi}${this.nombre}/updateExpediente`,{idUsuario, tipo,idExpediente, numeroExpediente, escuela, facultad, estudiantes})
      return resp.data;
    } catch (error) {
      return error;
    }
  }

  async validarExpediente(idExpediente:string ,idUsuario:string){

    try {
      const resp = await axios.put(`${this.rootInternet}${this.apiExpediente}${this.rootApi}${this.nombre}/validarExpediente`,{idUsuario, idExpediente})
      return resp.data;
    } catch (error) {
      return error;
    }
  }

  async deleteExpediente(idExpediente:string ,idUsuario:string){

    try {
      const resp = await axios.put(`${this.rootInternet}${this.apiExpediente}${this.rootApi}${this.nombre}/deleteExpediente`,{idUsuario, idExpediente})
      return resp.data;
    } catch (error) {
      return error;
    }
  }
 
    
}
