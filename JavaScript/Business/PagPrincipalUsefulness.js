import { GenerarChatsPrincipal } from "../Generadores/GenerarChat.js"
import { GenerarEventos } from "../Generadores/GenerarEventos.js"
import { GetAllEvento, GetUsuarioById, GetUsuarioChats, GetChatById, GetUsuarioByChat } from "../API/ServiceAPI.js"
import { showUser } from "./LocalStorage.js"
import { CambiarPagina } from "./PageChanger.js"

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

GetUsuarioChats(idUsuario).then(async chatUsuarios => {
    chatUsuarios.forEach(cu => {
        GetChatById(cu.chatId).then(chat => {
            console.log(chat.id + " " + idUsuario)

            GetUsuarioByChat(chat.id, idUsuario).then(async users => {

                console.log(users);

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


