import {PassportStrategy} from '@nestjs/passport'
import { ExtractJwt, Strategy } from 'passport-jwt';
import { JwtPayload } from '../interfaces/jwt-payload.interface';
import { ConfigService } from '@nestjs/config';
import { Injectable, UnauthorizedException} from '@nestjs/common';


@Injectable()
export class JwtStrategy extends PassportStrategy(Strategy){

    constructor(
        configService:ConfigService
    ){
        super({
            secretOrKey:configService.get('JWT_SECRET'),
            jwtFromRequest: ExtractJwt.fromAuthHeaderAsBearerToken()
        });
    }

    async validate(payload:JwtPayload){ 

        const {_id, exp, esEliminado, idSistema, idRol} = payload;
        const expira = new Date(exp * 1000);
        const fechaAhora= new Date();

        if(fechaAhora>expira || esEliminado)
         throw new UnauthorizedException('Token no valido')

        if(!idSistema){
            return {id:_id}
            
        }
        return  {id:_id, sistema:idSistema, rol:idRol};
    }

}