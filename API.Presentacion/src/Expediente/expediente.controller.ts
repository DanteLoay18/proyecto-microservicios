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
    async findAllExpedientes(@Query() paginationDto:ExpedientesPaginatedRequest) {
        return  this.expedienteService.findAllPaginated(paginationDto.page, paginationDto.pageSize);
        
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
    async findByBusqueda(@Query() findByBusquedaPaginatedRequest:FindByBusquedaPaginatedRequest) {

      return  this.expedienteService.findExpedienteByBusqueda(findByBusquedaPaginatedRequest);
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado, ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Post(ExpedienteRoutes.CreateExpediente)
    async createExpediente(@Body() createExpedienteRequest:CreateExpedienteRequest, @GetUser("id") usuarioCreacion:string) {

      return  this.expedienteService.createExpediente(usuarioCreacion, createExpedienteRequest, );
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado, ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Put(ExpedienteRoutes.UpdateExpediente)
    async updateExpediente(@Body() updateExpedienteRequest:UpdateExpedienteRequest, @GetUser("id") usuarioModificacion:string) {

      return  this.expedienteService.updateExpediente(usuarioModificacion, updateExpedienteRequest );
        
    }

    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Put(ExpedienteRoutes.ValidarExpediente)
    async validarExpediente(@Body() {idExpediente}:ValidarExpedienteRequest, @GetUser("id") usuarioModificacion:string) {

      return  this.expedienteService.validarExpediente(idExpediente,usuarioModificacion);
        
    }


    @ApiInternalServerErrorResponse({ description: 'Error server'})
    @ApiBearerAuth() 
    @RoleProtected(ValidRoles.encargado, ValidRoles.estudiante)
    @UseGuards(AuthGuard(), UserRoleGuard)
    @Delete(ExpedienteRoutes.EliminarExpediente)
    async eliminarExpediente(@Param("idExpediente") idExpediente:string, @GetUser("id") usuarioModificacion:string,) {

      return  this.expedienteService.deleteExpediente(idExpediente, usuarioModificacion);
        
    }

    
}
