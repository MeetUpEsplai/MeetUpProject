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
    constructor(chat, ultimoMensaje, userFoto) 
    {
        this.chat = chat;
        this.ultimoMensaje = ultimoMensaje;
        this.userFoto = userFoto;
    }

    GetChat() { return this.chat; }
    GetUltimoMensaje() { return this.ultimoMensaje; }
    GetUserFoto() { return this.userFoto; }
}