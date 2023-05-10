export class Comentario 
{
    constructor(id, fechaCreacion, texto, usuarioId, eventoId, comentarioPadreId) 
    {
        this.id = id;
        this.fechaCreacion = fechaCreacion;
        this.texto = texto;
        this.usuarioId = usuarioId;
        this.eventoId = eventoId;
        this.comentarioPadreId = comentarioPadreId;
    }

    GetId() { return this.id }
    GetTexto() { return this.texto; }
    GetFechaCreacion() { return this.fechaCreacion; }
    GetIdUsuario() { return this.usuarioId; }
    GetIdEvento() { return this.eventoId; }
    GetIdComentarioPadre() { return this.comentarioPadreId; }
}