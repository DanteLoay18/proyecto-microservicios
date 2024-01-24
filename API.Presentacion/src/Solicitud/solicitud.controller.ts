import { Controller, Get, UseGuards, Query,Param, Post, Body, Delete, Put, UseInterceptors, UploadedFile, ParseFilePipe, MaxFileSizeValidator, FileTypeValidator} from '@nestjs/common';
import { ApiBearerAuth, ApiInternalServerErrorResponse, ApiTags } from '@nestjs/swagger';
import { AuthGuard } from '@nestjs/passport';
import { UserRoleGuard } from 'src/Auth/jwt/guards/user-role/user-role.guard';
import { RoleProtected } from 'src/Auth/jwt/decorators/role-protected.decorator';
import { ValidRoles } from 'src/Auth/jwt/enums/valid-roles';
import { SolicitudRoutes } from './routes/solicitud.routes';
import { SolicitudService } from './solicitud.service';
import { CreateSolicitudRequest } from './dto/create-solicitud.request';
import { UpdateSolicitudRequest } from './dto/update-solicitud.request';

@ApiTags('Solicitud')
@Controller(SolicitudRoutes.Solicitud)
export class SolicitudController {
  constructor(private readonly solicitudService: SolicitudService) {}

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado, ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(SolicitudRoutes.SolicitudesGetAll)
    async findAllSolicitudes() {
        return  this.solicitudService.findAll();
        
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
    @Post(SolicitudRoutes.CreateSolicitud)
    async createSolicitud(@Body() createSolicitudRequest:CreateSolicitudRequest,){
      return this.solicitudService.createSolicitud(createSolicitudRequest);
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado,ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Put(SolicitudRoutes.UpdateSolicitud)
    async updateSolicitud(@Body() updateSolicitudRequest:UpdateSolicitudRequest){
      return this.solicitudService.updateSolicitud(updateSolicitudRequest);
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado,ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Delete(SolicitudRoutes.EliminarSolicitud)
    async deleteSolicitud(@Param("idSolicitud") idSolicitud:string){
      return this.solicitudService.deleteSolicitud(idSolicitud);
    }
}
