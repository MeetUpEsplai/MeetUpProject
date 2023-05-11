import { GetAllTipoReaccion, GetCountReaccionesEvento, GetEventoById, GetEventoCountSuscritos, GetUsuarioById, PostSuscripcion } from "../API/ServiceAPI.js"
import { show, showUser } from "./LocalStorage.js"
import { GenerarUsuarios } from "../Generadores/GeneradorUsuarios.js"
import { GenerarComentarios } from "../Generadores/GenerarComentarios.js";
import { GenerarFotos } from "../Generadores/GeneradorFotos.js";
import { UsuarioSuscribeEvento } from "../Modules/UsuarioSuscribeEventoClass.js";

var idEvento = show();

GetEventoById(idEvento).then(evento => {
    document.getElementById("parrafoDetalles").innerText = evento.descripcion;
    document.getElementById("parrafoHorario").innerText = evento.fechaEvento;
    document.getElementById("ubicacionGeneral").innerText = evento.ciudadProxima;
    document.getElementById("parrafoUbicacion").innerText = evento.coordenadas;
    
    GenerarComentarios(evento);
    GenerarFotos(evento);

    //Informacion dependiente del usuarioCreador
    GetUsuarioById(evento.usuarioId).then(usuario => {

        document.getElementById("nombreCreadora").innerText = usuario.nombre;

        console.log(usuario);

        if (usuario.referenciaFoto != null)
            document.getElementById("imgCreadoPor").src = usuario.referenciaFoto;
        else
            document.getElementById("imgCreadoPor").src = "../../imgEventDefault/fotoPerfilDefaul.png";

        //Informacion dependiente del usuarios Suscritos
        GetEventoCountSuscritos(idEvento).then(count => {
            document.getElementById("tituloAsistentes").innerText = "Asistentes (" + (count + 1) + ")";
        
            if (count > 0) {
                evento.usuarioSuscribeEventos.forEach(userSubEv => {
                    console.log(userSubEv)
                    
                    GetUsuarioById(userSubEv.usuarioId).then(usuario => {
                        GenerarUsuarios(usuario);
                    });
                });

                GetUsuarioById(evento.usuarioId).then(usuario => {
                    GenerarUsuarios(usuario);
                });
            }
        });
    }); 
});


GetAllTipoReaccion(idEvento).then(tipos => {
    tipos.forEach(tipo => {
        GetCountReaccionesEvento(idEvento, tipo.id).then(count => {
            document.getElementById("contador" + tipo.id).innerHTML = count;
        });
    });
});

document.getElementById("btnInscripcion").addEventListener('click', () => {
    var text = document.getElementById("btnInscripcion").innerHTML;
    if (text == "Inscribirme") 
    {
        document.getElementById("btnInscripcion").innerHTML = "Inscrito";
        document.getElementById("btnInscripcion").style.backgroundColor = "blue";

        var suscipcion = new UsuarioSuscribeEvento(0, showUser(), idEvento);
        PostSuscripcion(suscipcion);
    }
    else 
    {
        document.getElementById("btnInscripcion").innerHTML = "Inscribirme";
        document.getElementById("btnInscripcion").style.backgroundColor = "green";
    }

    
});