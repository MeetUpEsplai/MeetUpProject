import { getQuery, setQuery } from "./ConsultorAPI.js"

const ROOT = "https://localhost:7009/api";

const CHAT = "/Chats";
const COMENTARIO = "/Comentarios";
const ETIQUETA = "/Etiquetas";
const EVENTO = "/Eventos";
const FOTOS = "/Fotos";
const MENSJAES = "/Mensajes";
const TIPOREACCION ="/TipoReacciones";
const RCOMENTARIOS = "/UsuarioReaccionaComentarios";
const REVENTOS = "/UsuarioReaccionaEventos";
const RMENSJAES = "/UsuarioReaccionaMensajes";
const USUARIO = "/Usuarios";
const SUSCRIPCION = "/UsuarioSuscribeEventos";

const ID = "id_";
const NOMBRE = "nombre_"
const EMAIL = "email_"
const IDUSUARIO = "usuarioId_";
const IDETIQUETA = "etiquetaId_";
const IDEVENTO = "eventoId_";
const IDTIPOREACCION = "tipoReaccionId";
const IDCOMENTARIO = "comentarioId_";
const IDMENSAJE = "mensajeId_";

function Post(stringClase, modelo) { return setQuery(ROOT + stringClase, modelo); }
function Put(stringClase, modelo, id) { return setQuery(ROOT + stringClase + "/" + ID + id, modelo); }
function Get(stringClase, criterio) { return getQuery(ROOT + stringClase + "/" + criterio); }
function GetAll(stringClase) { return getQuery(ROOT + stringClase); }
function Delete(stringClase, id) { return getQuery(ROOT + stringClase + "/" + ID + id); }


//Crud Chat
export function PostChat(chatModel) { return Post(CHAT, chatModel); }


//Crud Comentario
export function PostComentario(comentarioModel) { return Post(COMENTARIO, comentarioModel); }
export function PutComentario(comentarioModel, idComentario) { return Put(COMENTARIO, comentarioModel, idComentario); }
export function GetComentarioById(idComentario) { return Get(COMENTARIO, ID + idComentario); }
export function DeleteComentario(idComentario) { return Delete(COMENTARIO, idComentario); }


//Crud Etiqueta
export function PostEtiqueta(etiquetaModel) { return Post(ETIQUETA, etiquetaModel); }
export function GetAllEtiquetas() { return GetAll(ETIQUETA) } 


//Crud Eventos
export function PostEvento(eventoModel) { return Post(EVENTO, eventoModel); }
export function PutEvento(eventoModel, idEvento) { return Put(EVENTO, eventoModel, idEvento); }
export function GetEventoById(idEvento) { return Get(EVENTO, ID + idEvento); }
export function GetAllEvento() { return GetAll(EVENTO); }
export function GetEventoByUsuario(idUsuario) { return Get(EVENTO, IDUSUARIO + idUsuario); }
export function GetEventoByEtiqueta(idEtiqueta) { return Get(EVENTO, IDETIQUETA + idEtiqueta); }
export function GetEventoByNombre(nombre) { return Get(EVENTO, NOMBRE + nombre); }
export function GetEventoCountSuscritos(idEvento) { return Get(EVENTO, IDEVENTO + idEvento); }
export function DeleteEvento(idEvento) { return Delete(EVENTO, idEvento); }


//Crud Fotos
export function PostFoto(fotoModel) { return Post(FOTOS, fotoModel); }
export function DeleteFoto(idFoto) { return Delete(FOTOS, idFoto); }


//Crud Mensajes
export function PostMensaje(mensajeModel) { return Post(MENSJAES, mensajeModel); }


//Crud TipoReaccion
export function PostTipoReaccion(tipoReaccionModel) { return Post(TIPOREACCION, tipoReaccionModel); }
export function GetAllTipoReaccion() { return GetAll(TIPOREACCION) } 


//Crud UsuarioReaccionaComentarios
export function PostReaccionComentario(reaccionComentarioModel) { return Post(RCOMENTARIOS, reaccionComentarioModel); }
export function GetReaccionComentario(idUsuario, idComentario, idTipoReaccion) { return Get(RCOMENTARIOS, IDUSUARIO + idUsuario + "," + IDCOMENTARIO + idComentario + "," + IDTIPOREACCION +  idTipoReaccion); }
export function GetCountReaccioesComentario(idComentario, idTipoReaccion) { return Get(RCOMENTARIOS, IDCOMENTARIO + idComentario + "," + IDTIPOREACCION +  idTipoReaccion); }
export function DeleteReaccionComentario(idReaccionComentario) { return Delete(RCOMENTARIOS, idReaccionComentario); }


//Crud UsuarioReaccionaEventos
export function PostReaccionEventos(reaccionEventosModel) { return Post(REVENTOS, reaccionEventosModel); }
export function GetReaccionEventos(idUsuario, idEventos, idTipoReaccion) { return Get(REVENTOS, IDUSUARIO + idUsuario + "," + IDEVENTO + idEventos + "," + IDTIPOREACCION +  idTipoReaccion); }
export function GetCountReaccionesEvento(idEventos, idTipoReaccion) { return Get(REVENTOS, IDEVENTO + idEventos + "," + IDTIPOREACCION +  idTipoReaccion); }
export function DeleteReaccionEvento(idReaccionEventos) { return Delete(REVENTOS, idReaccionEventos); }


//Crud UsuarioReaccionaMensaje
export function PostReaccionMensaje(reaccionMensajeModel) { return Post(RMENSJAES, reaccionMensajeModel); }
export function GetReaccionMensaje(idUsuario, idMensaje, idTipoReaccion) { return Get(REVENTOS, IDUSUARIO + idUsuario + "," + IDMENSAJE + idMensaje + "," + IDTIPOREACCION +  idTipoReaccion); }
export function GetCountReaccionesMensaje(idMensaje, idTipoReaccion) { return Get(REVENTOS, IDMENSAJE + idMensaje + "," + IDTIPOREACCION +  idTipoReaccion); }
export function DeleteReaccionMensaje(idReaccionMensaje) { return Delete(REVENTOS, idReaccionMensaje); }


//Crud Usuario
export function PostUsuario(usuarioModel) { return Post(USUARIO, usuarioModel); }
export function PutUsuario(usuarioModel, idUsuario) { return Put(USUARIO, usuarioModel, idUsuario); }
export function GetUsuarioById(idUsuario) { return Get(USUARIO, ID + idUsuario); }
export function GetAllUsuario() { return GetAll(USUARIO); }
export function GetUsuarioByNombre(nombre) { return Get(USUARIO, NOMBRE + nombre); }
export function GetUsuarioByEmail(email) { return Get(USUARIO, EMAIL + email); }
export function DeleteUsuario(idUsuario) { return Delete(USUARIO, idUsuario); }


//Cud UsuarioSuscritoEvento
export function PostSuscripcion(suscripcionModel) { return Post(SUSCRIPCION, suscripcionModel); }
//GET
export function DeleteSuscripciono(idSuscripcion) { return Delete(SUSCRIPCION, idSuscripcion); }