import { ApiProperty } from "@nestjs/swagger";
import { IsBoolean, IsNotEmpty } from "class-validator";

export class ModificarEstadoRequest{
    @ApiProperty()
    @IsBoolean()
    @IsNotEmpty()
    esInactivo:boolean
}