import { ApiProperty } from "@nestjs/swagger";
import { IsNotEmpty, IsString } from "class-validator";

export class AgregarSolicitudRequest{

    @ApiProperty({
        description:'id Solicitud'
    })
    @IsNotEmpty()
    @IsString()
    idSolicitud:string;

    @ApiProperty({
        description:'id Sesion'
    })
    @IsNotEmpty()
    @IsString()
    idSesion:string;

    @ApiProperty({
        description:'Observacion de la Solicitud'
    })
    @IsNotEmpty()
    @IsString()
    observacion:string;
}