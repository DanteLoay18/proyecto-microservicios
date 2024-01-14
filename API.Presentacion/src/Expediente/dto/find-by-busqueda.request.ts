import { ApiProperty } from "@nestjs/swagger";
import { Type } from "class-transformer";
import { IsOptional, IsPositive, IsString, Min } from "class-validator";


export class FindByBusquedaPaginatedRequest{
    @ApiProperty({
        required:false,
        nullable:true,
        description:'Tipo',
    })
    @IsPositive()
    @IsOptional()
    @Type(()=> Number)
    tipo?:number;

    @ApiProperty({
        required:false,
        nullable:true,
        description:'Numero Expediente',
    })
    @IsOptional()
    @IsString()
    numeroExpediente?:string;

    @ApiProperty({
        required:false,
        nullable:true,
        description:'Escuela',
    })
    @IsOptional()
    @IsString()
    escuela?:string;

    @ApiProperty({
        required:false,
        nullable:true,
        description:'Facultad',
    })
    @IsOptional()
    @IsString()
    facultad?:string;

    @ApiProperty({
        default:1,
        description:'Numero de pagina'
    })
    @IsPositive()
    @Type(()=> Number)
    page : number;

    @ApiProperty({
        default:10,
        description:'Cantidad de items en la pagina'
    })
    @Type(()=> Number)
    @Min(0)
    pageSize:number;
}