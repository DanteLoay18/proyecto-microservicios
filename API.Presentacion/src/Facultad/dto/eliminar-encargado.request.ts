import { ApiProperty } from "@nestjs/swagger";
import { IsNotEmpty, IsNumber } from "class-validator";

export class EliminarEncargadoRequest{
    @ApiProperty()
    @IsNumber()
    @IsNotEmpty()
    idFacultad:number;
}