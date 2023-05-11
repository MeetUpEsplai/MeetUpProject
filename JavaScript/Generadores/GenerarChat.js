import { ChatMini } from "../Modules/ChatClass.js"

export function GenerarChatsPrincipal(usuarios, chat) 
{
    var content = ApiToModelo(usuarios, chat)
    AddToHtmlPrincipal(content);
}

export function GenerarChatsPagChat(usuarios, chat) 
{
    var content = ApiToModelo(usuarios, chat)
    AddToHtmlChat(content);
}

function ApiToModelo(usuarios, chat)
{
    var ultimoMensaje = "";

    if (chat.mensajes.length != 0)
    {
        ultimoMensaje = chat.mensajes[chat.mensajes.length - 1]
    }
        

    var chatMini = new ChatMini(chat.id, ultimoMensaje, usuarios[0].referenciaFoto, usuarios[0].nombre);
        
    return chatMini;
}

function AddToHtmlPrincipal(arrayModelo) 
{
        var ultimoMensaje = arrayModelo.GetUltimoMensaje();
        var chatMini = arrayModelo;

        var contenedorGeneral = document.createElement("div"),
            contenedorImg = document.createElement("div"),
            img  = document.createElement("img"),
            contenedorData = document.createElement("div"),
            rowData = document.createElement("div"),
            contenedorNombre = document.createElement("div"),
            nombre = document.createElement("h5"),
            contenedorFecha = document.createElement("div"),
            fecha = document.createElement("h6"),
            contenedorMensaje = document.createElement("div"),
            mensaje = document.createElement("h5");

        //Declaracion de clases e ids
        contenedorGeneral.id = "chat_" + chatMini.GetChatId();
        contenedorGeneral.className = "row chat d-flex";
        contenedorImg.className = "col-3";
        img.className = "imgProfileUsers";
        contenedorData.className = "col-9";
        rowData.className = "row justify-content-between";
        contenedorNombre.className = "col-8";
        nombre.className = "fw-bolder";
        contenedorFecha.className = "col-4";
        contenedorMensaje.className = "row";

        //Add Data
        if (chatMini.GetUserFoto() != "")
                img.src = chatMini.GetUserFoto();
        else 
            img.src = "../../imgEventDefault/fotoPerfilDefaul.png";
                
        fecha.innerHTML = ultimoMensaje.fecha;
        nombre.innerHTML = chatMini.GetUserName();
        mensaje.innerHTML = ultimoMensaje.texto;

        //Asignar padre
        contenedorImg.appendChild(img);
        contenedorNombre.appendChild(nombre);
        contenedorFecha.appendChild(fecha);
        contenedorMensaje.appendChild(mensaje);
        rowData.appendChild(contenedorNombre);
        rowData.appendChild(contenedorFecha);
        contenedorData.appendChild(rowData);
        contenedorData.appendChild(contenedorMensaje);
        contenedorGeneral.appendChild(contenedorImg);
        contenedorGeneral.appendChild(contenedorData);

        document.getElementById("chatList").appendChild(contenedorGeneral);
        document.getElementById("chatList").appendChild(document.createElement("hr"));
    
}

function AddToHtmlChat(arrayModelo) 
{

        var ultimoMensaje = arrayModelo.GetUltimoMensaje();
        var chatMini = arrayModelo;

        var contenedorGeneral = document.createElement("a"),
            contenedorImg = document.createElement("div"),
            img  = document.createElement("img"),
            body = document.createElement("div"),
            contenedorUser = document.createElement("div"),
            nombre = document.createElement("h6"),
            fecha = document.createElement("small"),
            mensaje = document.createElement("p");
        
        //Declaracion de clases e ids
        contenedorGeneral.id = "chat_" + chatMini.GetChatId();
        contenedorGeneral.className = "list-group-item list-group-item-action active text-white rounded-0 chat";
        contenedorImg.className = "media";
        img.className = "rounded-circle";
        body.className = "media-body ml-4";
        contenedorUser.className = "d-flex align-items-center justify-content-between mb-1";
        nombre.className = "mb-0";
        fecha.className = "small font-weight-bold";
        mensaje.className = "font-italic mb-0 text-small";

        //Add Data
        img.alt = "user";
        img.width = "50";
        fecha.innerHTML = ultimoMensaje.fecha;
        nombre.innerHTML = chatMini.GetUserName();
        mensaje.innerHTML = ultimoMensaje.texto;

        if (chatMini.GetUserFoto() != "")
            img.src = chatMini.GetUserFoto();
        else 
            img.src = "../../imgEventDefault/fotoPerfilDefaul.png";

        contenedorUser.appendChild(nombre);
        contenedorUser.appendChild(fecha);
        body.appendChild(contenedorUser);
        body.appendChild(mensaje);
        contenedorImg.appendChild(img);
        contenedorImg.appendChild(body);
        contenedorGeneral.appendChild(contenedorImg);

        document.getElementById("listChat").appendChild(contenedorGeneral);
}