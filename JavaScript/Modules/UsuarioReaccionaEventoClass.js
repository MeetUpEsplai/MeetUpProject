export class UsuarioReaccionaeEvento
{
    constructor(id, eventoId, usuarioId, tipoReaccionId) 
    {
        this.id = id;
        this.eventoId = eventoId;
        this.usuarioId = usuarioId;
        this.tipoReaccionId = tipoReaccionId;
    }

    GetId() { return this.id }
    GetEventoId() {return this.eventoId }
    GetUsuarioId() {return this.usuarioId }
    GetTipoReaccionId() {return this.tipoReaccionId }
}   