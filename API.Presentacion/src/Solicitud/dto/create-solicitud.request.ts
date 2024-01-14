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
    @IsUUID()
    escuela:string;

    @ApiProperty({
        description:'id facultad Solicitud'
    })
    @IsUUID()
    facultad:string;

    @ApiProperty({
        description:'comentario Solicitud'
    })
    @IsString()
    comentario: string;

    @ApiProperty({
        description:'Nombre Archivo Solicitud',
    })
    @IsString()
    nombreArchivo: string;

    @ApiProperty({
        description:'documento url Solicitud',
    })
    @IsString()
    documento: string;

    
}



