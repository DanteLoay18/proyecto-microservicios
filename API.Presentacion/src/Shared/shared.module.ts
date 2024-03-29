import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';
import serverConfig from './config/server.config';
import * as Joi from "joi";

@Module({

    imports:[
        ConfigModule.forRoot({
            isGlobal: true,
            expandVariables: true,
            load: [
                serverConfig
            ],
            validationSchema: Joi.object({
                SERVER_PORT: Joi.number().default(3000),
            }),
            validationOptions: {
                allowUnknown: true,
                abortEarly: false,
            },
        })
    ]
})
export class SharedModule {}
