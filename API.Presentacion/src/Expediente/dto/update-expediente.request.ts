import { ApiProperty, PartialType } from "@nestjs/swagger";
import { CreateExpedienteRequest } from "./create-expediente.request";
import { IsNotEmpty, IsString } from "class-validator";


export class UpdateExpedienteRequest extends PartialType(CreateExpedienteRequest){
    @ApiProperty({
        description:'Id Expediente'
    })
    @IsNotEmpty()
    @IsString()
    idExpediente:string;
}