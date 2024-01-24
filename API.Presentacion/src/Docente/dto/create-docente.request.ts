import { ApiProperty } from "@nestjs/swagger";
import { IsNotEmpty, IsString, IsUUID, IsEmail } from "class-validator";


export class CreateDocenteRequest{


    @ApiProperty()
    @IsString()
    @IsNotEmpty()
    nombreCompleto:string

    @ApiProperty()
    @IsUUID()
    @IsNotEmpty()
    idEscuela:string

    @ApiProperty()
    @IsUUID()
    @IsNotEmpty()
    idFacultad:string

    @ApiProperty()
    @IsEmail()
    @IsNotEmpty()
    email:string;

    @ApiProperty()
    @IsString()
    @IsNotEmpty()
    numeroDocumento:string;
}