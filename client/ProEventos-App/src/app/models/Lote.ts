import { Evento } from "./Evento";

export interface Lote {
    id: number;
    name: string;
    preco: number;
    dateInicio?: Date;
    dataFim?: Date;
    quantidade: number;
    eventoId: number;
    evento: Evento;

}
