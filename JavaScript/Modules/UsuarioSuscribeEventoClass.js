export class UsuarioSuscribeEvento 
{
    constructor(id, usuarioId, eventoId) 
    {
        this.id = id;
        this.usuarioId = usuarioId;
        this.eventoId = eventoId;
    }

    GetId() { return this.id }
    GetIdUsuario() { return this.usuarioId; }
    GetIdEvento() { return this.eventoId; }
}