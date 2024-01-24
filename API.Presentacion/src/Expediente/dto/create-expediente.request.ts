import { ApiProperty } from "@nestjs/swagger";
import { IsArray, IsNotEmpty, IsNumber, IsOptional, IsString, IsUUID } from "class-validator";

export class Estudiante{
    @ApiProperty({
        description:'dni Estudiante'
    })
    dni: string;
    @ApiProperty({
        description:'nombre estudiante'
    })
    nombre: string;
}


export class CreateExpedienteRequest{

    @ApiProperty({
        description:'Tipo Expediente'
    })
    @IsNumber()
    tipo:number;

    @ApiProperty({
        description:'Numero Expediente Expediente'
    })
    @IsNotEmpty()
    @IsString()
    numeroExpediente?:string;

    @ApiProperty({
        description:'id escuela Expediente'
    })
    @IsNotEmpty()
    @IsNumber()
    idEscuela:number;

    @ApiProperty({
        description:'id facultad Expediente'
    })
    @IsNotEmpty()
    @IsNumber()
    idFacultad:number;

    @ApiProperty({
        description:'estudiantes Expediente',
        type:Estudiante,
        isArray:true
    })
    @IsArray()
    estudiantes: Estudiante[];

}



