import { Injectable,Inject, BadRequestException } from '@nestjs/common';
import { ClientProxy } from '@nestjs/microservices';

import { map, tap} from 'rxjs';
import { v4 } from 'uuid';
import { CreateDocenteRequest } from './dto/create-docente.request';
import { UpdateDocenteRequest } from './dto/update-docente.request';
import { FindByBusquedaPaginatedRequest } from './dto/find-by-busqueda';
import { ModificarEstadoRequest } from './dto/modificar-estado.request';
import { FindByEscuelaRequest } from './dto/find-by-escuela.request';
import axios from 'axios';

@Injectable()
export class DocenteService {
  
  private apiDocente = process.env.API_DOCENTE;
  private rootInternet = "http://";
  private rootApi = "/api/v1";
  private nombre = "/docente";
  
  async findAllPaginated(page:number, pageSize:number){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiDocente}${this.rootApi}${this.nombre}/findDocentesPaginated?Page=${page}&PageSize=${pageSize}`)
      return resp.data;
    } catch (error) {
      return error;
    }
  }

  async findOneById(idDocente:number){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiDocente}${this.rootApi}${this.nombre}/findDocenteById/${idDocente}`)
      return resp.data;
    } catch (error) {
      return error;
    }
  }
  
  async findByEscuela({idEscuela}:FindByEscuelaRequest){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiDocente}${this.rootApi}${this.nombre}/findDocentesByEscuela/${idEscuela}`);
      return resp.data;
    } catch (error) {
      throw new BadRequestException(error.message);
    }
  }

  async findByFacultad(idFacultad:string){
    try {
      const resp = await axios.get(`${this.rootInternet}${this.apiDocente}${this.rootApi}${this.nombre}/findDocentesByFacultad/${idFacultad}`);
      return resp.data;
    } catch (error) {
      throw new BadRequestException(error.message);
    }
  }

  async findByBusqueda({page, pageSize, email, idEscuela, idFacultad,nombreCompleto}:FindByBusquedaPaginatedRequest){
    try {

      const urlParams = new URLSearchParams();

      if (page) urlParams.append('Page',""+page);
      if (pageSize) urlParams.append('PageSize', ""+pageSize);
      if (idEscuela) urlParams.append('IdEscuela', idEscuela);
      if (email) urlParams.append('Email', email);
      if (idFacultad) urlParams.append('IdFacultad', idFacultad);
      if (nombreCompleto) urlParams.append('NombreCompleto', nombreCompleto);

      const resp = await axios.get(`${this.rootInternet}${this.apiDocente}${this.rootApi}${this.nombre}/findDocentesByBusqueda?${urlParams.toString()}`);
           
      return resp.data;
    } catch (error) {
      throw new BadRequestException(error.message);
    }
  }

  async createDocente(createDocenteRequest:CreateDocenteRequest, idUsuario:string){
    try {
      const resp = await axios.post(`${this.rootInternet}${this.apiDocente}${this.rootApi}${this.nombre}/createDocente`,{...createDocenteRequest, idUsuario});
      return resp.data;
    } catch (error) {
      throw new BadRequestException(error.message);
    }
  }

  async updateDocente(idDocente:string,updateDocenteRequest:UpdateDocenteRequest, idUsuario:string){
    try {
      const resp = await axios.put(`${this.rootInternet}${this.apiDocente}${this.rootApi}${this.nombre}/updateDocente`,{...updateDocenteRequest,idDocente, idUsuario});
      return resp.data;
    } catch (error) {
      throw new BadRequestException(error.message);
    }
  }

  async deleteDocente(idDocente:string, idUsuario:string){
    try {
      const resp = await axios.put(`${this.rootInternet}${this.apiDocente}${this.rootApi}${this.nombre}/deleteDocente`,{idDocente, idUsuario});
      return resp.data;
    } catch (error) {
      throw new BadRequestException(error.message);
    }
  }
    
}
