import { GetEventoById, GetEventoCountSuscritos, GetUsuarioById } from "../API/ServiceAPI.js"
import { show } from "./LocalStorage.js"
import { GenerarUsuarios } from "../Generadores/GeneradorUsuarios.js"
import { GenerarComentarios } from "../Generadores/GenerarComentarios.js";

var idEvento = show();
var idEvento = 2; //Para Test

GetEventoById(idEvento).then(evento => {
    document.getElementById("parrafoDetalles").innerText = evento.descripcion;
    document.getElementById("parrafoHorario").innerText = evento.fechaEvento;
    document.getElementById("ubicacionGeneral").innerText = evento.ciudadProxima;
    document.getElementById("parrafoUbicacion").innerText = evento.coordenadas;
    
    GenerarComentarios(evento);

    GetUsuarioById(evento.usuarioId).then(usuario => {

        document.getElementById("nombreCreadora").innerText = usuario.nombre;

        if (usuario.referenciaFotoPrincipal != null)
            document.getElementById("imgCreadoPor").src = usuario.referenciaFotoPrincipal;
        else
            document.getElementById("imgCreadoPor").src = "../../imgEventDefault/fotoPerfilDefaul.png";

        GetEventoCountSuscritos(idEvento).then(count => {
            document.getElementById("tituloAsistentes").innerText = "Asistentes (" + count + ")";
        
            if (count > 0) {
                usuario.usuarioSuscribeEventos.forEach(userSubEv => {
                    GetUsuarioById(userSubEv.usuarioId).then(usuario => {
                        GenerarUsuarios(usuario);
                    });
                });
            }

        });

    }); 

});

