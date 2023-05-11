import { GetChatById, GetUsuarioChats, GetUsuarioByChat, PostMensaje  } from "../API/ServiceAPI.js"
import { GenerarMensajes } from "../Generadores/GeneradorMensajes.js";
import { GenerarChatsPagChat } from "../Generadores/GenerarChat.js";
import { show, showUser } from "./LocalStorage.js"
import { Mensaje } from "../Modules/MensajeClass.js"
import { AddUnoToHtml } from "../Generadores/GeneradorMensajes.js";
import { Usuario } from "../Modules/UsuarioClass.js";

var userId = showUser();
var chatId = show();

if (chatId == null)
    chatId = 1;

//Descomentar Para Funcionamiento completo
AddNuevosMensajes(chatId, userId);

GetUsuarioChats(userId).then(usChatList => {
    usChatList.forEach(usChat => {
        GetChatById(usChat.chatId).then(chat => {
            GetUsuarioByChat(chat.id, userId).then( users => {
                GenerarChatsPagChat(users, chat);

                const chats = document.querySelectorAll('.chat');

                chats.forEach(div => {
                    div.addEventListener('click', () => 
                    {
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

document.getElementById("button-addon2").addEventListener('click', () => 
{
    var mensaje = document.getElementById("mensajeNuevo").value;

    if (mensaje != "") {
        var f = new Date();
        var fString = f.getDay() + "/" + f.getMonth() + "/" + f.getFullYear() + " " + f.getHours() + ":" + f.getMinutes();
        var mnsj = new Mensaje(0, fString, mensaje, chatId, userId);
        PostMensaje(mnsj);

        AddUnoToHtml(mnsj, userId);
    }
});