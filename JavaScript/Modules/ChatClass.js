export class Chat 
{
    constructor(id, nombre, fechaCreacion, idsUsuarios) 
    {
        this.id = id;
        this.nombre = nombre;
        this.fechaCreacion = fechaCreacion;
        this.idsUsuarios = idsUsuarios;
    }
    
    GetId() { return this.id }
    GetNombre() { return this.nombre; }
    GetFechaCreacion() { return this.fechaCreacion; }
    GetIdsUsuarios() { return this.idsUsuarios; }
}


export class ChatMini 
{
    constructor(chatId, ultimoMensaje, userFoto, userName) 
    {
        this.chatId = chatId;
        this.ultimoMensaje = ultimoMensaje;
        this.userFoto = userFoto;
        this.userName = userName;
    }

    GetChatId() { return this.chatId; }
    GetUltimoMensaje() { return this.ultimoMensaje; }
    GetUserFoto() { return this.userFoto; }
    GetUserName() { return this.userName; }
}