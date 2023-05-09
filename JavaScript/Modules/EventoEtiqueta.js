export class EventoEtiqueta 
{
    constructor(etiquetaId, eventoId)
    {
        this.etiquetaId = etiquetaId;
        this.eventoId = eventoId;
    }

    GetEtiquetaId() { return this.etiquetaId; }
    GetEventoId() { return this.eventoId; }
}