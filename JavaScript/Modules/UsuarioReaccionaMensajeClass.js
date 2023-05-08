export class UsuarioReaccionaeMensaje
{
    constructor(id, mensjaeId, usuarioId, tipoReaccionId) 
    {
        this.id = id;
        this.mensjaeId = mensjaeId;
        this.usuarioId = usuarioId;
        this.tipoReaccionId = tipoReaccionId;
    }

    GetId() { return this.id }
    GetMensajeId() {return this.mensjaeId }
    GetUsuarioId() {return this.usuarioId }
    GetTipoReaccionId() {return this.tipoReaccionId }
}   