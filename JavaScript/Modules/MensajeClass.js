export class Mensaje {
    constructor(id, fecha, texto, chatId, usuarioId) 
    {
        this.id = id;
        this.fecha = fecha;
        this.texto = texto;
        this.chatId = chatId;
        this.usuarioId = usuarioId;
    }

    GetId() { return this.id }
    GetFecha() { return this.fecha; }
    GetTexto() { return this.texto; } 
    GetChatId() { return this.chatId; }
    GetUsuarioId() { return this.usuarioId; }
}