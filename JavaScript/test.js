import { PostFoto, GetAllEvento, GetEventoById, GetEventoByUsuario, GetEventoCountSuscritos, PostChat, PostEtiqueta, PostEvento, PostSuscripcion, PostTipoReaccion } from "./API/ServiceAPI.js";
import { Evento, EventoContent } from "./Modules/EventoClass.js"
import { GenerarEventos } from "./Generadores/GenerarEventos.js";
import { TipoReaccion } from "./Modules/TipoReaccionClass.js";
import { Etiqueta } from "./Modules/EtiquetaClass.js";
import { UsuarioSuscribeEvento } from "./Modules/UsuarioSuscribeEventoClass.js";
import { Foto } from "./Modules/FotoClass.js";


console.log(PostFoto(new Foto(1, "a", 2)));

