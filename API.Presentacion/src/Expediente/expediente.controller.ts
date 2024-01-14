import { Controller, Get, UseGuards, Query,Param, Post, Body, Delete, Put} from '@nestjs/common';
import { ApiBearerAuth, ApiInternalServerErrorResponse, ApiTags } from '@nestjs/swagger';
import { AuthGuard } from '@nestjs/passport';
import { UserRoleGuard } from 'src/Auth/jwt/guards/user-role/user-role.guard';
import { RoleProtected } from 'src/Auth/jwt/decorators/role-protected.decorator';
import { ValidRoles } from 'src/Auth/jwt/enums/valid-roles';
import { GetUser } from 'src/Auth/jwt/decorators/get-user.decorator';
import { ExpedienteRoutes } from './routes/expediente.routes';
import { ExpedienteService } from './expediente.service';
import { ExpedientesPaginatedRequest } from './dto/expediente-paginated.request';
import { CreateExpedienteRequest } from './dto/create-expediente.request';
import { FindByBusquedaPaginatedRequest } from './dto/find-by-busqueda.request';
import { UpdateExpedienteRequest } from './dto/update-expediente.request';
import { ValidarExpedienteRequest } from './dto/validar-expediente.request';

@ApiTags('Expediente')
@Controller(ExpedienteRoutes.Expediente)
export class ExpedienteController {
  constructor(private readonly expedienteService: ExpedienteService) {}

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado, ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(ExpedienteRoutes.ExpedientesGetAllPaginated)
    async findAllExpedientes(@Query() paginationDto:ExpedientesPaginatedRequest, @GetUser("rol") rolUsuario:string, @GetUser("id") idUsuario:string) {
        return  this.expedienteService.findAllPaginated(paginationDto.page, paginationDto.pageSize,rolUsuario, idUsuario);
        
    }
    
    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado,ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(ExpedienteRoutes.ExpedienteById)
    async findById(@Param('idExpediente') idExpediente:string) {

      return  this.expedienteService.findOneById(idExpediente);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado,ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Get(ExpedienteRoutes.ExpedientesByBusqueda)
    async findByBusqueda(@Query() findByBusquedaPaginatedRequest:FindByBusquedaPaginatedRequest,@GetUser("rol") rolUsuario:string, @GetUser("id") idUsuario:string) {

      return  this.expedienteService.findByBusqueda(findByBusquedaPaginatedRequest, rolUsuario, idUsuario);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado, ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Post(ExpedienteRoutes.CreateExpediente)
    async createExpediente(@Body() createExpedienteRequest:CreateExpedienteRequest,@GetUser("rol") rolUsuario:string, @GetUser("id") usuarioCreacion:string) {

      return  this.expedienteService.createExpediente(createExpedienteRequest,rolUsuario, usuarioCreacion);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado, ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Put(ExpedienteRoutes.UpdateExpediente)
    async updateExpediente(@Body() updateExpedienteRequest:UpdateExpedienteRequest,@GetUser("rol") rolUsuario:string, @GetUser("id") usuarioModificacion:string) {

      return  this.expedienteService.updateExpediente(updateExpedienteRequest,rolUsuario, usuarioModificacion);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Put(ExpedienteRoutes.ValidarExpediente)
    async validarExpediente(@Body() validarExpedienteRequest:ValidarExpedienteRequest, @GetUser("id") usuarioModificacion:string) {

      return  this.expedienteService.validarExpediente(validarExpedienteRequest,usuarioModificacion);
        
    }


    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado, ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Delete(ExpedienteRoutes.EliminarExpediente)
    async eliminarExpediente(@Param("idExpediente") idExpediente:string, @GetUser("id") usuarioModificacion:string, @GetUser("rol") rolUsuario:string) {

      return  this.expedienteService.eliminarExpediente(idExpediente,rolUsuario, usuarioModificacion);
        
    }

    
}
