import { ApiProperty } from "@nestjs/swagger";
import { Type } from "class-transformer";
import { IsOptional, IsPositive, IsString, IsUUID, Min } from "class-validator";

export class FindByBusquedaPaginatedRequest{
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

    @ApiProperty({
        required:false,
        nullable:true
    })
    @IsString()
    @IsOptional()
    nombreCompleto:string;

    @ApiProperty({
        required:false,
        nullable:true
    })
    @IsString()
    @IsOptional()
    email:string;

    @ApiProperty({
        required:false,
        nullable:true
    })
    @IsUUID()
    @IsOptional()
    idEscuela:string;

    @ApiProperty({
        required:false,
        nullable:true
    })
    @IsUUID()
    @IsOptional()
    idFacultad:string;
}