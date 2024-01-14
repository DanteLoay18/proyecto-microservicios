import { ApiProperty } from "@nestjs/swagger";
import { Type } from "class-transformer";
import { IsPositive, Min } from "class-validator";


export class ExpedientesPaginatedRequest{
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