import { GetAllEvento, GetEventoById, GetEventoCountSuscritos, PostChat, PostEtiqueta, PostEvento, PostTipoReaccion } from "./API/ServiceAPI.js";
import { Evento, EventoContent } from "./Modules/EventoClass.js"
import { GenerarEventos } from "./Generadores/GenerarEventos.js";
import { TipoReaccion } from "./Modules/TipoReaccionClass.js"

var etiqueta = new TipoReaccion(1, "Manolo", ":)");

console.log(PostTipoReaccion(etiqueta));


GetAllEvento().then(async (result) => {
    var eventosContent = [];

    for (var i = 0; i < result.length; i++) 
    {
        var actual = result[i];

        var evento = new Evento(
            actual.id, 
            actual.nombre,
            actual.fechaEvento,
            actual.precio,
            actual.descripcion,
            actual.coordenadas,
            actual.ciudadProxima,
            actual.referenciaFotoPrincipal,
            actual.usuarioId,
            null)

            console.log(parseInt(actual.id));

            await GetEventoCountSuscritos(evento.id).then((result) => {
                eventosContent.push(new EventoContent(evento, result + 1))
            });
    }

    console.log("pasa");
    GenerarEventos(eventosContent);
});

