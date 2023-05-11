import { GetChatById, GetUsuarioChats, GetUsuarioByChat  } from "../API/ServiceAPI.js"
import { GenerarMensajes } from "../Generadores/GeneradorMensajes.js";
import { GenerarChatsPagChat } from "../Generadores/GenerarChat.js";
import { show, showUser } from "./LocalStorage.js"

var userId = showUser();

//Descomentar Para Funcionamiento completo
AddNuevosMensajes(1, userId);

GetUsuarioChats(userId).then(usChatList => {
    usChatList.forEach(usChat => {
        GetChatById(usChat.chatId).then(chat => {
            GetUsuarioByChat(chat.id, userId).then(async users => {
                GenerarChatsPagChat(users, chat);

                const chats = document.querySelectorAll('.chat');

                chats.forEach(div => {
                    div.addEventListener('click', () => 
                    {
                        console.log("papa");
                        EliminarCacheMensajes();
                        const id = div.id.split('_')[1];
                        AddNuevosMensajes(id);
                    });
                })
            });
        });
    });
});

function EliminarCacheMensajes() {
    var divElement = document.getElementById("listaMensajes");

    while (divElement.firstChild) 
        divElement.removeChild(divElement.firstChild);
}


function AddNuevosMensajes(chatId) 
{
    GetChatById(chatId).then(chat => {
        GenerarMensajes(chat, userId);
    });
}