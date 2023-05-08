import { GetAllEvento, GetEventoById, GetEventoCountSuscritos, PostChat, PostEtiqueta, PostEvento, PostTipoReaccion } from "./API/ServiceAPI.js";
import { Evento, EventoContent } from "./Modules/EventoClass.js"
import { GenerarEventos } from "./Generadores/GenerarEventos.js";
import { TipoReaccion } from "./Modules/TipoReaccionClass.js";
import { Etiqueta } from "./Modules/EtiquetaClass.js";


PostTipoReaccion(new TipoReaccion(1, "carita triste", ":("));

PostEtiqueta(new Etiqueta(1, "testeo Epico"));
