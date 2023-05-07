export class Chat 
{
    constructor(nombre, fechaCreacion, idsUsuarios) 
    {
        this.nombre = nombre;
        this.fechaCreacion = fechaCreacion;
        this.idsUsuarios = idsUsuarios;
    }
        
    GetNombre() { return this.nombre; }
    GetFechaCreacion() { return this.fechaCreacion; }
    GetIdsUsuarios() { return this.idsUsuarios; }
}