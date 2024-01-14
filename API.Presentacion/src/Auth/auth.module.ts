import { Module} from '@nestjs/common';
import { PassportModule } from '@nestjs/passport';
import { JwtModule } from '@nestjs/jwt';
import { ConfigModule, ConfigService } from '@nestjs/config';
import { JwtStrategy } from './jwt/strategies/jwt.strategy';
import { ClientProxyFactory, Transport } from '@nestjs/microservices';
import { UsuarioService } from './usuario.service';

@Module({
  imports:[
        PassportModule.register({defaultStrategy:'jwt'}),
        JwtModule.registerAsync({
            imports:[ConfigModule],
            inject:[ConfigService],
            useFactory: (configService:ConfigService) => {

                return {
                    secret: configService.get('JWT_SECRET'),
                    signOptions:{
                        expiresIn:'4h'
                    }
                }
            }
        }),
       
  ],
  controllers: [],
  providers: [    
              JwtStrategy,
              UsuarioService,
              {
                provide: 'USUARIO_SERVICE_TRANSPORT',
                useFactory: (configService: ConfigService) => {
                  const usuario_queue=configService.get<string>('QUEUE_USUARIO')
                  const host = configService.get<string>('TRANSPORT_HOST_USUARIO');
                  const port = parseInt(configService.get<string>('TRANSPORT_PORT_USUARIO'));
          
                  return ClientProxyFactory.create({
                    transport: Transport.RMQ,
                    options: {
                      urls: [`amqp://${host}:${port}`],
                      queue: usuario_queue,
                      queueOptions: {
                        durable: false, 
                      }
                    },
                  });
                },
                inject: [ConfigService],
              }
        ],
  exports:[
    JwtModule,
    PassportModule,
    UsuarioService

  ]
})
export class AuthModule {}
