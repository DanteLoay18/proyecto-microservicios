import { ApiProperty } from "@nestjs/swagger";
import { IsBoolean, IsString, IsUUID } from "class-validator";

export class CambiarEstadoRequest{
    
    @ApiProperty({
        description:'Id Solicitud'
    })
    @IsUUID()
    idSolicitud:string;

    @ApiProperty({
        description:'Observacion Solicitud'
    })
    @IsString()
    observacion:string;

    @ApiProperty({
        description:'Es Aceptado Solicitud'
    })
    @IsBoolean()
    esAceptado:boolean;
}