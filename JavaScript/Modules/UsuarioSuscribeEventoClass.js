export class UsuarioSuscribeEvento 
{
    constructor(idUsuario, idEvento) 
    {
        this.idUsuario = idUsuario;
        this.idEvento = idEvento;
    }

    GetIdUsuario() { return this.idUsuario; }
    GetIdEvento() { return this.idEvento; }
}