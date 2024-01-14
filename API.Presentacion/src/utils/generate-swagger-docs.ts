import { INestApplication } from "@nestjs/common";
import { DocumentBuilder, SwaggerModule } from "@nestjs/swagger";

export function generateSwaggerDocs(app: INestApplication) {
    
    const config = new DocumentBuilder()
        .setTitle('Sistema de Solicitudes Grados y Titulos')
        .setVersion('1.0')
        .addBearerAuth()
        .build();

    const document = SwaggerModule.createDocument(app, config);
    SwaggerModule.setup('api', app, document);
    
}