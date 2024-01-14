import { Controller, Get, UseGuards, Query, Param, Post, Body, Put } from '@nestjs/common';
import { ApiBearerAuth, ApiInternalServerErrorResponse, ApiTags } from '@nestjs/swagger';
import { AuthGuard } from '@nestjs/passport';
import { UserRoleGuard } from 'src/Auth/jwt/guards/user-role/user-role.guard';
import { RoleProtected } from 'src/Auth/jwt/decorators/role-protected.decorator';
import { ValidRoles } from 'src/Auth/jwt/enums/valid-roles';
import { GetUser } from 'src/Auth/jwt/decorators/get-user.decorator';
import { SesionService } from './sesion.service';
import { SesionRoutes } from './routes/sesion.routes';
import { CreateSesionRequest } from './dto/create-sesion.request';
import { SesionesPaginatedRequest } from './dto/find-all-paginado.request';
import { FindByBusquedaPaginatedRequest } from './dto/find-by-busqueda.request';
import { UpdateSesionRequest } from './dto/update-sesion.request';
import { AgregarSolicitudRequest } from './dto/agregar-solicitud.request';
import { FindSolicitudesBySesionRequest } from './dto/find-solicitudes-by-sesion.request';

@ApiTags('Sesion')
@Controller(SesionRoutes.Sesion)
export class SesionController {
    
  constructor(private readonly sesionService: SesionService) {}

  @ApiInternalServerErrorResponse({ description: 'Error server'})
  @ApiBearerAuth() 
  @RoleProtected(ValidRoles.encargado)
  @UseGuards(AuthGuard(), UserRoleGuard)
  @Get(SesionRoutes.FindUltimaIteracionMiembroComision)
  async findUltimaIteracionMiembroComision(@GetUser("id") idUsuario:string) {
      return  this.sesionService.findUltimoIteracionMiembroComision(idUsuario);
      
  }

  @ApiInternalServerErrorResponse({ description: 'Error server'})
  @ApiBearerAuth() 
  @RoleProtected(ValidRoles.encargado)
  @UseGuards(AuthGuard(), UserRoleGuard)
  @Get(SesionRoutes.SesionsGetAllPaginated)
  async findAllExpedientes(@Query() paginationDto:SesionesPaginatedRequest, @GetUser("id") idUsuario:string) {
      return  this.sesionService.findAllPaginated(paginationDto.page, paginationDto.pageSize, idUsuario);
      
  }
  
  @ApiInternalServerErrorResponse({ description: 'Error server'})
  @ApiBearerAuth() 
  @RoleProtected(ValidRoles.encargado)
  @UseGuards(AuthGuard(), UserRoleGuard)
  @Get(SesionRoutes.SesionById)
  async findById(@Param('idSesion') idSesion:string) {

    return  this.sesionService.findOneById(idSesion);
      
  }

  @ApiInternalServerErrorResponse({ description: 'Error server'})
  @ApiBearerAuth() 
  @RoleProtected(ValidRoles.encargado)
  @UseGuards(AuthGuard(), UserRoleGuard)
  @Get(SesionRoutes.SesionSolicitudesById)
  async findSolicitudesBySesion( @Query() paginationDto:FindSolicitudesBySesionRequest,) {

    return  this.sesionService.findSolicitudesBySesion(paginationDto.idSesion, paginationDto.page, paginationDto.pageSize);
      
  }

  @ApiInternalServerErrorResponse({ description: 'Error server'})
  @ApiBearerAuth() 
  @RoleProtected(ValidRoles.encargado)
  @UseGuards(AuthGuard(), UserRoleGuard)
  @Get(SesionRoutes.SesionsByBusqueda)
  async findByBusqueda(@Query() findByBusqueda:FindByBusquedaPaginatedRequest, @GetUser("id") idUsuario:string) {

    return  this.sesionService.findByBusqueda(findByBusqueda, idUsuario);
      
  }

  @ApiInternalServerErrorResponse({ description: 'Error server'})
  @ApiBearerAuth() 
  @RoleProtected(ValidRoles.encargado)
  @UseGuards(AuthGuard(), UserRoleGuard)
  @Post(SesionRoutes.CreateSesion)
  async createSesion(@Body() createSesionRequest:CreateSesionRequest, @GetUser("id") usuarioCreacion:string) {

    return  this.sesionService.createSesion(createSesionRequest, usuarioCreacion);
      
  }

  @ApiInternalServerErrorResponse({ description: 'Error server'})
  @ApiBearerAuth() 
  @RoleProtected(ValidRoles.encargado)
  @UseGuards(AuthGuard(), UserRoleGuard)
  @Put(SesionRoutes.UpdateSesion)
  async updateSesion(@Body() updateSesionRequest:UpdateSesionRequest, @GetUser("id") usuarioModificacion:string) {

    return  this.sesionService.updateSesion(updateSesionRequest, usuarioModificacion);
      
  }

  @ApiInternalServerErrorResponse({ description: 'Error server'})
  @ApiBearerAuth() 
  @RoleProtected(ValidRoles.encargado)
  @UseGuards(AuthGuard(), UserRoleGuard)
  @Put(SesionRoutes.AgregarSolicitud)
  async agregarSolicitud(@Body() agregarSolicitudRequest:AgregarSolicitudRequest, @GetUser("id") usuarioModificacion:string) {

    return  this.sesionService.agregarSolicitud(agregarSolicitudRequest, usuarioModificacion);
      
  }
    
}
