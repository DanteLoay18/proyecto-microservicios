import { ApiProperty } from "@nestjs/swagger";
import {IsNotEmpty, IsNumber, IsString, IsUUID} from 'class-validator'
export class AsignarEncargadoRequest{

    @ApiProperty()
    @IsString()
    @IsNotEmpty()
    idEncargado : string;


    @ApiProperty()
    @IsNumber()
    @IsNotEmpty()
    idFacultad:number;
}