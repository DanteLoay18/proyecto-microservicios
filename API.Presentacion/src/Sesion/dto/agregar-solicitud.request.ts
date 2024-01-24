import { ApiProperty } from "@nestjs/swagger";
import { IsNotEmpty, IsNumber, IsString } from "class-validator";

export class AgregarSolicitudRequest{

    @ApiProperty({
        description:'id Solicitud'
    })
    @IsNotEmpty()
    @IsNumber()
    idSolicitud:number;

    @ApiProperty({
        description:'id Sesion'
    })
    @IsNotEmpty()
    @IsNumber()
    idSesion:number;

    @ApiProperty({
        description:'Observacion de la Solicitud'
    })
    @IsNotEmpty()
    @IsString()
    observacion:string;
}