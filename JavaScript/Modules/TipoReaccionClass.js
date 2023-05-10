export class TipoReaccion 
{
    constructor(id, nombre, emoji) 
    {
        this.id = id;
        this.nombre = nombre;
        this.emoji = emoji;
    }

    GetId() { return this.id }
    GetNombre() { return this.nombre; }
    GetEmoji() { return this.emoji; }
}