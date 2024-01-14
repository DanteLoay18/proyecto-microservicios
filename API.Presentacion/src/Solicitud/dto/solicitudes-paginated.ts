import { ApiProperty } from "@nestjs/swagger";
import { Type } from "class-transformer";
import { IsOptional, IsPositive,IsUUID, Min } from "class-validator";


export class SolicitudesPaginatedRequest{
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
        nullable:true,
        required:false,
        description:'Id Expediente'
    })
    @IsOptional()
    @IsUUID()
    idExpediente:string;
}