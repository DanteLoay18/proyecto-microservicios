import { ApiProperty } from "@nestjs/swagger";
import { IsNotEmpty, IsString, IsUUID } from "class-validator";


export class CreateSesionRequest{

    @ApiProperty({
        description:'Numero Sesion'
    })
    @IsNotEmpty()
    @IsString()
    numeroSesion:string;

    @ApiProperty({
        description:'Fecha Sesion'
    })
    @IsNotEmpty()
    @IsString()
    fechaSesion:string;

    @ApiProperty({
        description:'Presidente Sesion'
    })
    @IsNotEmpty()
    @IsUUID()
    presidente:string;

    @ApiProperty({
        description:'Miembro1  Sesion'
    })
    @IsNotEmpty()
    @IsUUID()
    miembro1: string;

    @ApiProperty({
        description:'Miembro2  Sesion'
    })
    @IsNotEmpty()
    @IsUUID()
    miembro2: string;

    @ApiProperty({
        description:'Miembro3 Sesion'
    })
    @IsNotEmpty()
    @IsUUID()
    miembro3: string;


}



