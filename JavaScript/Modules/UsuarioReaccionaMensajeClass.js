export class UsuarioReaccionaeMensaje
{
    constructor(mensjaeId, usuarioId, tipoReaccionId) {
        this.mensjaeId = mensjaeId;
        this.usuarioId = usuarioId;
        this.tipoReaccionId = tipoReaccionId;
    }

    GetMensajeId() {return this.mensjaeId }
    GetUsuarioId() {return this.usuarioId }
    GetTipoReaccionId() {return this.tipoReaccionId }
}   