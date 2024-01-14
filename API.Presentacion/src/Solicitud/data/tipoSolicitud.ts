
export interface TipoSolicitud{
    label:string;
    value:number;
    tipoExpediente:number;
}

export const tipoSolicitud : TipoSolicitud[]=[
    {
        label:"SOLICITUD DE CAMBIO DE ASESOR",
        value:1,
        tipoExpediente:1
    },
    {
        label:"SOLICITUD DE CAMBIO DE JURADO",
        value:2,
        tipoExpediente:1
    },
    {
        label:"SOLICITUD DE CAMBIO DE TITULO",
        value:3,
        tipoExpediente:1
    },
    {
        label:"SOLICITUD DE FECHA DE SUSTENTACION",
        value:4,
        tipoExpediente:1
    },
    {
        label:"SOLICITUD DE REVISION PRESENCIAL",
        value:5,
        tipoExpediente:1
    },
    {
        label:"SOLICITUD DE ANULACION DE TESIS",
        value:6,
        tipoExpediente:1
    },
    {
        label:"SOLICITUD DE BACHILLER",
        value:7,
        tipoExpediente:2
    },
    {
        label:"SOLICITUD DE TITULO",
        value:8,
        tipoExpediente:3
    }
]