import { ApiProperty } from "@nestjs/swagger";
import { IsNotEmpty, IsNumber, IsString, IsUUID } from "class-validator";


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
    @IsString()
    presidente:string;

    @ApiProperty({
        description:'Miembro1  Sesion'
    })
    @IsNotEmpty()
    @IsString()
    miembro1: string;

    @ApiProperty({
        description:'Miembro2  Sesion'
    })
    @IsNotEmpty()
    @IsString()
    miembro2: string;

    @ApiProperty({
        description:'Miembro3 Sesion'
    })
    @IsNotEmpty()
    @IsString()
    miembro3: string;

    @ApiProperty({
        description:'Id Facultad'
    })
    @IsNotEmpty()
    @IsNumber()
    facultad:number;


}



