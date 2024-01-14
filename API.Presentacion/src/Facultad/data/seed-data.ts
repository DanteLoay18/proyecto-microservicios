import {v4} from 'uuid'

interface SeedEscuela {
    _id:string,
    nombre:string
}

interface SeedFacultad{
    nombre:string,
    escuelas:SeedEscuela[],
    encargado:string;
}

interface SeedData {
    facultades: SeedFacultad[];
}


export const initialData: SeedData = {
    
    facultades: [
        {
            nombre: "FACULTAD DE INGENIERIA DE SISTEMAS E INGENIERIA CIVIL",
            escuelas:[
                {
                    _id:v4(),
                    nombre:"ESCUELA DE INGENIERIA CIVIL"
                },
                {
                    _id:v4(),
                    nombre:"ESCUELA DE INGENIERIA DE SISTEMAS"
                }
            ],
            encargado:""
        },        
        {
            nombre: "FACULTAD DE CIENCIAS DE LA SALUD",
            escuelas:[
                {
                    _id:v4(),
                    nombre:"ESCUELA DE ENFERMERIA"
                },
                {
                    _id:v4(),
                    nombre:"ESCUELA DE PSICOLOGIA"
                }
            ],
            encargado:""
        },
        {
            nombre: "FACULTAD DE CIENCIAS AGROPECUARIAS",
            escuelas:[
                {
                    _id:v4(),
                    nombre:"ESCUELA DE AGRONOMIA"
                },
                {
                    _id:v4(),
                    nombre:"ESCUELA DE INGENIERIA AGROINDUSTRIAL"
                }
            ],
            encargado:""
        },
        {
            nombre: "FACULTAD DE CIENCIAS FORESTAS Y AMBIENTALES",
            escuelas:[
                {
                    _id:v4(),
                    nombre:"ESCUELA DE INGENIERIA FORESTAL"
                },
                {
                    _id:v4(),
                    nombre:"ESCUELA DE INGENIERIA AMBIENTAL"
                }
            ],
            encargado:""
        },
        {
            nombre: "FACULTAD DE MEDICINA HUMANA",
            escuelas:[
                {
                    _id:v4(),
                    nombre:"ESCUELA DE MEDICINA HUMANA"
                },
            ],
            encargado:""
        },
    ]
}