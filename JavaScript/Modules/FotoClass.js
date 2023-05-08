export class Foto {
    constructor(id, referencia, eventoId) 
    {
        this.id = id;
        this.referencia = referencia;
        this.eventoId = eventoId;
    }

    GetId() { return this.id }
    GetReferencia() { return this.referencia; }
    GetEventoId() { return this.eventoId; }
}
