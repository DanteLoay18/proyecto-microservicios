

import { ApiProperty, PartialType } from "@nestjs/swagger";
import { IsNotEmpty, IsNumber, IsString } from "class-validator";
import { CreateSesionRequest } from "./create-sesion.request";


export class UpdateSesionRequest extends PartialType(CreateSesionRequest){
    @ApiProperty({
        description:'Id Sesion'
    })
    @IsNotEmpty()
    @IsNumber()
    idSesion:number;
}