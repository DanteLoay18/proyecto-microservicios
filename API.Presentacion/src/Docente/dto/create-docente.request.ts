import { ApiProperty } from "@nestjs/swagger";
import { IsNotEmpty, IsString, IsUUID, IsEmail } from "class-validator";


export class CreateDocenteRequest{


    @ApiProperty()
    @IsString()
    @IsNotEmpty()
    nombreCompleto:string

    @ApiProperty()
    @IsNotEmpty()
    idEscuela:number

    @ApiProperty()
    @IsNotEmpty()
    idFacultad:number

    @ApiProperty()
    @IsEmail()
    @IsNotEmpty()
    email:string;

    @ApiProperty()
    @IsString()
    @IsNotEmpty()
    numeroDocumento:string;
}