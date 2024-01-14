import { PartialType } from "@nestjs/swagger";
import { CreateDocenteRequest } from "./create-docente.request";

export class UpdateDocenteRequest extends PartialType(CreateDocenteRequest){}
    