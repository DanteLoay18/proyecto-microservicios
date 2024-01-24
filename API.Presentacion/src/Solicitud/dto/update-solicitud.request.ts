import { ApiProperty, PartialType } from "@nestjs/swagger";
import { CreateSolicitudRequest } from "./create-solicitud.request";
import { IsNumber, IsUUID } from "class-validator";


export class UpdateSolicitudRequest extends PartialType(CreateSolicitudRequest){
    @ApiProperty({
        description:'Tipo Solicitud'
    })
    @IsNumber()
    idSolicitud:number;
}