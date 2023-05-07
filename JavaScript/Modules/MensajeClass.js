export class Mensaje {
    constructor(fecha, texto, chatId, usuarioId) {
        this.fecha = fecha;
        this.texto = texto;
        this.chatId = chatId;
        this.usuarioId = usuarioId;
    }

    GetFecha() { return this.fecha; }
    GetTexto() { return this.texto; } 
    GetChatId() { return this.chatId; }
    GetUsuarioId() { return this.usuarioId; }
}