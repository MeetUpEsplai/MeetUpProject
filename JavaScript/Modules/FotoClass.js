export class Foto {
    constructor(referencia, eventoId) {
        this.referencia = referencia;
        this.eventoId = eventoId;
    }

    GetReferencia() { return this.referencia; }
    GetEventoId() { return this.eventoId; }
}
