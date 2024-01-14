import { ApiProperty } from "@nestjs/swagger";
import { IsArray, IsNumber, IsOptional, IsString, IsUUID } from "class-validator";

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

export class Jurado{
    @ApiProperty({
        description:'Cargo Jurado'
    })
    @IsString()
   cargo: string;

   @ApiProperty({
    description:'Id Docente Jurado'
   })
   @IsUUID()
   docente:string;
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
    @IsOptional()
    @IsString()
    numeroExpediente?:string;

    @ApiProperty({
        description:'Titulo Proyecto Expediente'
    })
    @IsOptional()
    @IsString()
    tituloProyecto?:string;

    @ApiProperty({
        description:'id escuela Expediente'
    })
    @IsUUID()
    escuela:string;

    @ApiProperty({
        description:'id facultad Expediente'
    })
    @IsUUID()
    facultad:string;

    @ApiProperty({
        description:'estudiantes Expediente',
        type:Estudiante,
        isArray:true
    })
    @IsArray()
    estudiantes: Estudiante[];

    @ApiProperty({
        description:'jurados Expediente',
        type: Jurado,
        isArray: true
    })
    @IsOptional()
    jurados?: Jurado[];

    @ApiProperty({
        description:'Asesor Expediente'
    })
    @IsString()
    @IsOptional()
    asesor ?:string;

    @ApiProperty({
        description:'Fecha Sustentacion Expediente'
    })
    @IsString()
    @IsOptional()
    fechaSustentacion?:string;
}



