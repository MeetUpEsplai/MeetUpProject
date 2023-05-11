import { GenerarChatsPrincipal } from "../Generadores/GenerarChat.js"
import { GenerarEventos } from "../Generadores/GenerarEventos.js"
import { GetAllEvento, GetUsuarioById, GetUsuarioChats, GetChatById, GetUsuarioByChat, PostEvento } from "../API/ServiceAPI.js"
import { showUser } from "./LocalStorage.js"
import { CambiarPagina } from "./PageChanger.js"
import { Evento } from "../Modules/EventoClass.js"

var idUsuario = showUser();

function AddClickCambiarPagina(listDivs, isChat) {
    listDivs.forEach(div => {
        div.addEventListener('click', () => {
            const id = div.id.split('_')[1];
            if (isChat)
                CambiarPagina("../../chat/chat.html", idUsuario, id);
            else
                CambiarPagina("../../evento/evento.html", idUsuario, id);
        });
    });
}

GetUsuarioById(idUsuario).then(user => {
    document.getElementById("imgProfileUsers").src = user.referenciaFoto;
});

GetUsuarioChats(idUsuario).then(async chatUsuarios => {
    chatUsuarios.forEach(cu => {
        GetChatById(cu.chatId).then(chat => {

            GetUsuarioByChat(chat.id, idUsuario).then(async users => {

                await GenerarChatsPrincipal(users, chat);
    
                const eventos = document.querySelectorAll('.chat');
    
                AddClickCambiarPagina(eventos, true);
            });
        });
    });
    
});

GetAllEvento().then(async eventos => {

    await GenerarEventos(eventos);

    const chats = document.querySelectorAll('.evento');

    AddClickCambiarPagina(chats, false);
});


document.getElementById("btnEnviar").addEventListener('click', () => {
    var nombre = document.getElementById("nombreEvento").value,
        desc = document.getElementById("descripcionEvento").value,
        foto = document.getElementById("fotoPerfilEvento").value,
        ubi = document.getElementById("ubicacion").value,
        date = document.getElementById("pick-date").value;

    var evento = new Evento(0, nombre, date, 0, desc, ubi, "", foto, idUsuario, null);

    if (nombre != "" && desc != "" && date != "" && ubi != "") 
    {
        console.log("Pasa");
        PostEvento(evento);
        CambiarPagina("../../aplicacion/aplicacion.html", idUsuario, null);
    }
});

