import { INestApplication, ValidationPipe } from '@nestjs/common';
import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';
import { ConfigService } from '@nestjs/config';
import { generateSwaggerDocs } from './utils/generate-swagger-docs';
import { ServerConfig } from 'src/Shared/config/server.config';

function getServerConfig(app: INestApplication): ServerConfig {
  const config: ConfigService = app.get(ConfigService)
  return config.get<ServerConfig>('server')
}

async function bootstrap() {
  const app = await NestFactory.create(AppModule);
  const config = getServerConfig(app)
  app.setGlobalPrefix('api')
  
  generateSwaggerDocs(app)

  app.enableCors({
    origin: ['http://localhost:4202']
  });

  app.useGlobalPipes( 
    new ValidationPipe({
      whitelist: true,
      forbidNonWhitelisted: true,
    })
   );

  await app.listen(config.port);

}
bootstrap();
