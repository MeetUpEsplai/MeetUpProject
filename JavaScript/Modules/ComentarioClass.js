export class Comentario 
{
    constructor(fechaCreacion, texto, usuarioId, eventoId, comentarioPadreId) 
    {
        this.fechaCreacion = fechaCreacion;
        this.texto = texto;
        this.usuarioId = usuarioId;
        this.eventoId = eventoId;
        this.comentarioPadreId = comentarioPadreId;
    }

    GetTexto() { return this.texto; }
    GetFechaCreacion() { return this.fechaCreacion; }
    GetIdUsuario() { return this.usuarioId; }
    GetIdEvento() { return this.eventoId; }
    GetIdComentarioPadre() { return this.comentarioPadreId; }
}