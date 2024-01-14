export enum TipoEpediente{
    TipoPilar = 1,
    TipoBachiller = 2,
    TipoTitulo = 3,
}

export const tipoDescripcion: Record<TipoEpediente, string> = {
    [TipoEpediente.TipoPilar]: "Tipo Pilar",
    [TipoEpediente.TipoBachiller]: "Tipo Bachiller",
    [TipoEpediente.TipoTitulo]: "Tipo Titulo",
  };