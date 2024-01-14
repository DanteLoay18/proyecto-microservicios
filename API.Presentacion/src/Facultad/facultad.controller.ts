import { Controller, Get, Post, Put, Body,Param, UseGuards, ParseUUIDPipe, Query } from '@nestjs/common';
import { ApiBearerAuth, ApiInternalServerErrorResponse, ApiTags } from '@nestjs/swagger';
import { AuthGuard } from '@nestjs/passport';
import { GetUser } from 'src/Auth/jwt/decorators/get-user.decorator';
import { FacultadRoutes } from './routes/escuela.routes';
import { FacultadService } from './facultad.service';
import { FacultadesPaginatedRequest } from './dto/facultades-paginated.request';
import { map } from 'rxjs';
import { UserRoleGuard } from 'src/Auth/jwt/guards/user-role/user-role.guard';
import { RoleProtected } from 'src/Auth/jwt/decorators/role-protected.decorator';
import { ValidRoles } from 'src/Auth/jwt/enums/valid-roles';
import { EliminarEncargadoRequest } from './dto/eliminar-encargado.request';
import { AsignarEncargadoRequest } from './dto/asignar-encargado.request';

@ApiTags('Facultad')
@Controller(FacultadRoutes.Facultad)
export class FacultadController {
  constructor(private readonly facultadService: FacultadService) {}

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() //Si no esta autenticado no puede usar el metodo
    @RoleProtected(ValidRoles.admin) // Roles permitidos
    @UseGuards(AuthGuard(), UserRoleGuard) 
    @Get(FacultadRoutes.FacultadsGetAllPaginated) //findAllPaginated
    async findAllFacultadsPaginado(@Query() paginationDto:FacultadesPaginatedRequest) {
        
        return this.facultadService.findAllPaginated(paginationDto.page, paginationDto.pageSize)
        
    }
  
    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.admin)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(FacultadRoutes.FacultadById)
    async findFacultadById(@Param('idFacultad') idFacultad:string) {
        
        return this.facultadService.findOneById(idFacultad);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.admin,ValidRoles.estudiante, ValidRoles.encargado)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(FacultadRoutes.FacultadesListado)
    async facultadesListado() {
        return this.facultadService.findAllFacultades();
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.admin, ValidRoles.estudiante, ValidRoles.encargado)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(FacultadRoutes.EscuelasByFacultad)
    async facultadesByEscuela(@Param('idFacultad') idFacultad:string) {
        return this.facultadService.findEscuelasByFacultad(idFacultad)
    }


    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.admin)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Put(FacultadRoutes.FacultadAsignarEncargado)
    async asignarEncargadoFacultad(@GetUser("id") idUsuario:string, @Body() asignarEncargadoRequest:AsignarEncargadoRequest) {

         return await this.facultadService.asignarEncargadoFacultad(idUsuario, asignarEncargadoRequest);     
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.admin)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Put(FacultadRoutes.FacultadEliminarEncargado)
    async eliminarEncargadoFacultad(@GetUser("id") idUsuario:string,@Body() eliminarEncargadoRequest:EliminarEncargadoRequest) {

         return this.facultadService.quitarEncargadoFacultad(eliminarEncargadoRequest,idUsuario);    
    }

  
}
