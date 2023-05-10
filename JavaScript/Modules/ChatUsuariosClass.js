export class ChatUsuarios 
{
    constructor(chatId, usuarioId)
    {
        this.chatId = chatId;
        this.usuarioId = usuarioId;
    }

    GetChatId() { return this.chatId; }
    GetUsuarioId() { return this.usuarioId; }
}