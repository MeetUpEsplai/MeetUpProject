export class UsuarioSuscribeEvento 
{
    constructor(id, idUsuario, idEvento) 
    {
        this.id = id;
        this.idUsuario = idUsuario;
        this.idEvento = idEvento;
    }

    GetId() { return this.id }
    GetIdUsuario() { return this.idUsuario; }
    GetIdEvento() { return this.idEvento; }
}