import { ApiProperty } from "@nestjs/swagger";
import { IsNotEmpty, IsUUID } from "class-validator";


export class ValidarExpedienteRequest{
    @ApiProperty({
        description:'Id Expediente'
    })
    @IsNotEmpty()
    @IsUUID()
    idExpediente:string;
}