import { Controller, Get, UseGuards, Query,Param, Post, Body, Delete, Put, UseInterceptors, UploadedFile, ParseFilePipe, MaxFileSizeValidator, FileTypeValidator} from '@nestjs/common';
import { ApiBearerAuth, ApiInternalServerErrorResponse, ApiTags } from '@nestjs/swagger';
import { AuthGuard } from '@nestjs/passport';
import { UserRoleGuard } from 'src/Auth/jwt/guards/user-role/user-role.guard';
import { RoleProtected } from 'src/Auth/jwt/decorators/role-protected.decorator';
import { ValidRoles } from 'src/Auth/jwt/enums/valid-roles';
import { GetUser } from 'src/Auth/jwt/decorators/get-user.decorator';
import { SolicitudRoutes } from './routes/solicitud.routes';
import { SolicitudService } from './solicitud.service';
import { SolicitudesPaginatedRequest } from './dto/solicitudes-paginated';
import { FileInterceptor } from '@nestjs/platform-express';
import { CreateSolicitudRequest } from './dto/create-solicitud.request';
import { UpdateSolicitudRequest } from './dto/update-solicitud.request';
import { CambiarEstadoRequest } from './dto/cambiar-estado-solicitud.request';
import { SolicitudesPaginatedNoRevisadoRequest } from './dto/solicitudes-paginated-no-revisado.request';

@ApiTags('Solicitud')
@Controller(SolicitudRoutes.Solicitud)
export class SolicitudController {
  constructor(private readonly solicitudService: SolicitudService) {}

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado, ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(SolicitudRoutes.SolicitudesGetAllPaginatedNoRevisados)
    async findAllSolicitudesNoRevisadas(@Query() paginationDto:SolicitudesPaginatedNoRevisadoRequest,@GetUser("id") idUsuario:string) {
        return  this.solicitudService.findAllPaginatedNoRevisado(paginationDto.page, paginationDto.pageSize, idUsuario);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado, ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(SolicitudRoutes.SolicitudesGetAllPaginated)
    async findAllSolicitudes(@Query() paginationDto:SolicitudesPaginatedRequest,@GetUser("id") idUsuario:string) {
        return  this.solicitudService.findAllPaginated(paginationDto.page, paginationDto.pageSize,paginationDto.idExpediente, idUsuario);
        
    }
    
    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado,ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(SolicitudRoutes.SolicitudById)
    async findById(@Param('idSolicitud') idSolicitud:string) {

      return  this.solicitudService.findOneById(idSolicitud);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado,ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(SolicitudRoutes.SolicitudByIdAndExpediente)
    async findByIdAndExpediente(@Param('idSolicitud') idSolicitud:string) {

      return  this.solicitudService.findOneByIdSolicitudExpediente(idSolicitud);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado,ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(SolicitudRoutes.FiltrarTipoSolicitud)
    async filtrarTipoSolicitud(@Param('tipoExpediente') tipoExpediente:string) {

      return  this.solicitudService.filtrarTipoSolicitud(Number(tipoExpediente));
        
    }

  
    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado,ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Post(SolicitudRoutes.CreateSolicitud)
    async createSolicitud(@Body() createSolicitudRequest:CreateSolicitudRequest, @GetUser("id") usuarioCreacion:string){
      return this.solicitudService.createSolicitud(createSolicitudRequest, usuarioCreacion);
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado,ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Put(SolicitudRoutes.UpdateSolicitud)
    async updateSolicitud(@Body() updateSolicitudRequest:UpdateSolicitudRequest, @GetUser("id") usuarioCreacion:string){
      return this.solicitudService.updateSolicitud(updateSolicitudRequest, usuarioCreacion);
    }


    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado,ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Put(SolicitudRoutes.CambiarEstadoSolicitud)
    async cambiarEstadoSolicitud(@Body() cambiarEstadoRequest:CambiarEstadoRequest, @GetUser("id") usuarioCreacion:string){
      return this.solicitudService.cambiarEstadoSolicitud(cambiarEstadoRequest, usuarioCreacion);
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado,ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Delete(SolicitudRoutes.EliminarSolicitud)
    async deleteSolicitud(@Param("idSolicitud") idSolicitud:string, @GetUser("id") usuarioCreacion:string){
      return this.solicitudService.deleteSolicitud(idSolicitud, usuarioCreacion);
    }
}
