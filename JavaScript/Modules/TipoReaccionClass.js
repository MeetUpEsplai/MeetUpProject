export class Tipo 
{

    constructor(nombre, emoji) 
    {
        this.nombre = nombre;
        this.emoji = emoji;
    }

    GetNombre() { return this.nombre; }
    GetEmoji() { return this.emoji; }
}