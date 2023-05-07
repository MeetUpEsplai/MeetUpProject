export class UsuarioReaccionaeEvento
{
    constructor(eventoId, usuarioId, tipoReaccionId) {
        this.eventoId = eventoId;
        this.usuarioId = usuarioId;
        this.tipoReaccionId = tipoReaccionId;
    }

    GetEventoId() {return this.eventoId }
    GetUsuarioId() {return this.usuarioId }
    GetTipoReaccionId() {return this.tipoReaccionId }
}   