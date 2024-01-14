export interface JwtPayload{
    _id:string;
    exp:number;
    esEliminado:boolean;
    idSistema?:string;
    idRol?:string;
}