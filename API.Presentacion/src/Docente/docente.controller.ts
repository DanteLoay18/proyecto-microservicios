import { Controller, Get, UseGuards, Query,Param, Post, Body, Put} from '@nestjs/common';
import { ApiBearerAuth, ApiInternalServerErrorResponse, ApiTags } from '@nestjs/swagger';
import { AuthGuard } from '@nestjs/passport';
import { UserRoleGuard } from 'src/Auth/jwt/guards/user-role/user-role.guard';
import { RoleProtected } from 'src/Auth/jwt/decorators/role-protected.decorator';
import { ValidRoles } from 'src/Auth/jwt/enums/valid-roles';
import { DocenteRoutes } from './routes/docente.routes';
import { DocenteService } from './docente.service';
import { DocentesPaginatedRequest } from './dto/docentes-paginated.request';
import { GetUser } from 'src/Auth/jwt/decorators/get-user.decorator';
import { CreateDocenteRequest } from './dto/create-docente.request';
import { UpdateDocenteRequest } from './dto/update-docente.request';
import { FindByBusquedaPaginatedRequest } from './dto/find-by-busqueda';
import { ModificarEstadoRequest } from './dto/modificar-estado.request';
import { FindByEscuelaRequest } from './dto/find-by-escuela.request';

@ApiTags('Docente')
@Controller(DocenteRoutes.Docente)
export class DocenteController {
  constructor(private readonly docenteService: DocenteService) {}

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.admin, ValidRoles.encargado)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(DocenteRoutes.DocentesGetAllPaginated)
    async findAllDocentes(@Query() paginationDto:DocentesPaginatedRequest, @GetUser("id") idUsuario:string) {
        return  this.docenteService.findAllPaginated(paginationDto.page, paginationDto.pageSize,idUsuario);
        
    }
    
    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.admin, ValidRoles.encargado)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(DocenteRoutes.DocenteById)
    async findById(@Param('idDocente') idDocente:string) {

      return  this.docenteService.findOneById(idDocente);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.admin, ValidRoles.encargado)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(DocenteRoutes.DocentesByBusqueda)
    async findByBusqueda(@Query() findByBusquedaPaginatedRequest:FindByBusquedaPaginatedRequest, @GetUser("id") idUsuario:string) {

      return  this.docenteService.findByBusqueda(findByBusquedaPaginatedRequest, idUsuario);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.estudiante, ValidRoles.encargado)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(DocenteRoutes.DocentesByEscuela)
    async findByEscuela(@Query() findByEscuelaRequest:FindByEscuelaRequest) {

      return  this.docenteService.findByEscuela(findByEscuelaRequest);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(DocenteRoutes.DocentesByFacultad)
    async findByFacultad(@GetUser("id") idUsuario:string) {

      return  this.docenteService.findByFacultad(idUsuario);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.admin)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Post(DocenteRoutes.CreateDocente)
    async createDocente(@Body() createDocenteRequest:CreateDocenteRequest, @GetUser("id") usuarioCreacion:string) {

      return  this.docenteService.createDocente(createDocenteRequest, usuarioCreacion);
        
    }
    
    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.admin)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Put(DocenteRoutes.UpdateDocente)
    async updateDocente(@Param("idDocente") idDocente:string,@Body() updateDocenteRequest:UpdateDocenteRequest, @GetUser("id") usuarioModificacion:string) {

      return  this.docenteService.updateDocente(idDocente,updateDocenteRequest, usuarioModificacion);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.admin)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Put(DocenteRoutes.ModificarEstado)
    async modificarEstado(@Param("idDocente") idDocente:string,@Body() modificarEstadoRequest:ModificarEstadoRequest, @GetUser("id") usuarioModificacion:string) {

      return  this.docenteService.modificarEstado(idDocente,modificarEstadoRequest, usuarioModificacion);
        
    }
  
}
