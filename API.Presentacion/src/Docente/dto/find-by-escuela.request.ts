import { ApiProperty } from "@nestjs/swagger";
import { IsUUID } from "class-validator";

export class FindByEscuelaRequest{
    @ApiProperty({
        description:'id Escuela'
    })
    @IsUUID()
    idEscuela : string;

}