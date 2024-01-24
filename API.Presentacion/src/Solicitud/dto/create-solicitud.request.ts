import { ApiProperty } from "@nestjs/swagger";
import {IsNumber, IsString, IsUUID } from "class-validator";

export class CreateSolicitudRequest{

    @ApiProperty({
        description:'Tipo Solicitud'
    })
    @IsNumber()
    tipoSolicitud:number;

    @ApiProperty({
        description:'Id Expediente'
    })
    @IsUUID()
    expediente?:string;

    @ApiProperty({
        description:'id escuela Solicitud'
    })
    @IsNumber()
    escuela:number;

    @ApiProperty({
        description:'id facultad Solicitud'
    })
    @IsNumber()
    facultad:number;

    @ApiProperty({
        description:'comentario Solicitud'
    })
    @IsString()
    comentario: string;

    
}



