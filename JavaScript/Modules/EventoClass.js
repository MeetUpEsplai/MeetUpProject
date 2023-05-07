export class Evento 
{
    constructor(nombre, fechaEvento, precio, descripcion, coordenadas, ciudadProxima, usuarioId, idsEtiquetas) 
    {
        this.nombre = nombre;
        this.fechaEvento = fechaEvento;
        this.precio = precio;
        this.descripcion = descripcion;
        this.coordenadas = coordenadas;
        this.ciudadProxima = ciudadProxima;
        this.usuarioId = usuarioId;
        this.idsEtiquetas = idsEtiquetas;
    }

    GetNombre() { return this.nombre; }
    GetFechaEvento() { return this.fechaEvento; }
    GetPrecio() { return this.precio; }
    GetDescripcion() { return this.descripcion; }
    GetCoordenadas() { return this.coordenadas; }
    GetCiudadProxima() { return this.ciudadProxima; }
    GetUsuarioId() { return this.usuarioId; }
    GetIdsEtiquetas() { return this.idsEtiquetas; }
}