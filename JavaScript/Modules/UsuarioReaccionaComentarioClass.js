export class UsuarioReaccionaComentario 
{
    constructor(comentarioId, usuarioId, tipoReaccionId) {
        this.comentarioId = comentarioId;
        this.usuarioId = usuarioId;
        this.tipoReaccionId = tipoReaccionId;
    }

    GetComentarioId() {return this.comentarioId }
    GetUsuarioId() {return this.usuarioId }
    GetTipoReaccionId() {return this.tipoReaccionId }
}