import { GenerarChats } from "../Generadores/GenerarChat.js"
import { GenerarEventos } from "../Generadores/GenerarEventos.js"
import { GetAllEvento, GetUsuarioById } from "../API/ServiceAPI.js"

function AddClickCambiarPagina(listDivs, tipoPag) {
    listDivs.forEach(chat => {
        evento.addEventListener('click', () => {
            const id = chat.id.split('_')[1];
            //Cambiar pagina chat con id
        });
    });
}


GetUsuarioById(1).then(async user =>{
    await GenerarChats(user);

    const eventos = document.querySelectorAll('.chat');

    AddClickCambiarPagina(eventos, "evento");
});

GetAllEvento().then(async eventos => {
    await GenerarEventos(eventos);

    const chats = document.querySelectorAll('.evento');

    AddClickCambiarPagina(chats, "chat");
});


