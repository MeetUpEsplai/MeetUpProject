export class UsuarioReaccionaComentario 
{
    constructor(id, comentarioId, usuarioId, tipoReaccionId) 
    {
        this.id = id;
        this.comentarioId = comentarioId;
        this.usuarioId = usuarioId;
        this.tipoReaccionId = tipoReaccionId;
    }

    GetId() { return this.id }
    GetComentarioId() {return this.comentarioId }
    GetUsuarioId() {return this.usuarioId }
    GetTipoReaccionId() {return this.tipoReaccionId }
}