export class Evento 
{
    constructor(id, nombre, fechaEvento, precio, descripcion, coordenadas, ciudadProxima, referenciaFotoPrincipal, usuarioId, idsEtiquetas) 
    {
        this.id = id;
        this.nombre = nombre;
        this.fechaEvento = fechaEvento;
        this.precio = precio;
        this.descripcion = descripcion;
        this.coordenadas = coordenadas;
        this.ciudadProxima = ciudadProxima;
        this.referenciaFotoPrincipal = referenciaFotoPrincipal;
        this.usuarioId = usuarioId;
        this.idsEtiquetas = idsEtiquetas;
    }

    GetId() { return this.id }
    GetNombre() { return this.nombre; }
    GetFechaEvento() { return this.fechaEvento; }
    GetPrecio() { return this.precio; }
    GetDescripcion() { return this.descripcion; }
    GetCoordenadas() { return this.coordenadas; }
    GetCiudadProxima() { return this.ciudadProxima; }
    GetFotoPrincipal() { return this.referenciaFotoPrincipal; }
    GetUsuarioId() { return this.usuarioId; }
    GetIdsEtiquetas() { return this.idsEtiquetas; }
}

export class EventoContent 
{
    constructor(evento, countSuscritos) 
    {
        this.evento = evento;
        this.countSuscritos = countSuscritos;
    }

    GetEvento() { return this.evento; }
    GetCount() { return this.countSuscritos; }
}