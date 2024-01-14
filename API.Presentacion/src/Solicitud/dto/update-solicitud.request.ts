import { ApiProperty, PartialType } from "@nestjs/swagger";
import { CreateSolicitudRequest } from "./create-solicitud.request";
import { IsUUID } from "class-validator";


export class UpdateSolicitudRequest extends PartialType(CreateSolicitudRequest){
    @ApiProperty({
        description:'Tipo Solicitud'
    })
    @IsUUID()
    idSolicitud:string;
}