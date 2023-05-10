import { ChatMini } from "../Modules/ChatClass.js"

export function GenerarChatsPrincipal(usuario) 
{
    content = ApiToModelo(usuario)
    AddToHtmlPrincipal(content);
}

export function GenerarChatsPagChat(usuario) 
{
    content = ApiToModelo(usuario)
    AddToHtmlChat(content);
}

function ApiToModelo(usuario)
{
    var chats = usuario.chats;
    var chatContent = [];

    for (var i = 0; i < chats.length; i++) 
    {
        var usuarioschat = chats.usuarios
        var nombreUsuario;
        var fotoUsuario;
        var numMensajes = chats.mensajes.length;
        var ultimoMensaje = chats.mensajes[numMensajes - 1];

        for (var j = 0; j < usuarioschat.length; j++)
        {
            if (usuarioschat[i].id != usuario.id)
            {
                nombreUsuario = usuarioschat[i].referenciaFoto;
                fotoUsuario = usuarioschat[i].referenciaFoto;
            }
        }

        chatContent.push(new ChatMini(chats[i].id, ultimoMensaje, fotoUsuario, nombreUsuario));
    }

    return chatContent;
}

function AddToHtmlPrincipal(arrayModelo) 
{
    for (var i = 0; i < arrayModelo.length; i++) 
    {
        var ultimoMensaje = arrayModelo[i].GetUltimoMensaje();
        var chatMini = arrayModelo[i];

        var contenedorGeneral = document.createElement("div"),
            contenedorImg = document.createElement("div"),
            img  = document.createElement("img"),
            contenedorData = document.createElement("div"),
            rowData = document.createElement("div"),
            colData = document.createElement("div"),
            contenedorNombre = document.createElement("div"),
            nombre = document.createElement("h5"),
            contenedorFecha = document.createElement("div"),
            fecha = document.createElement("h6"),
            contenedorMensaje = document.createElement("div"),
            mensaje = document.createElement("h5");

        //Declaracion de clases e ids
        contenedorGeneral.id = "chat_" + chatMini.GetChatId();
        contenedorGeneral.className = "row chat";
        contenedorImg.className = "col-3";
        img.className = "imgProfileUsers";
        contenedorData.className = "col-9";
        rowData.className = "row";
        contenedorNombre.className = "col-9";
        nombre.className = "fw-bolder";
        contenedorFecha.className = "col-1";
        contenedorMensaje.className = "row";

        //Add Data
        if (modelo.GetUserFoto() != null)
                img.src = chatMini.GetUserFoto();
        else 
            img.src = "";
                
        fecha.innerHTML = ultimoMensaje.GetFecha();
        nombre.innerHTML = modelo.GetUserName();
        mensaje.innerHTML = modelo.GetTexto();

        //Asignar padre
        contenedorImg.appendChild(img);
        contenedorNombre.appendChild(nombre);
        contenedorFecha.appendChild(fecha);
        contenedorMensaje.appendChild(mensaje);
        colData.appendChild(contenedorNombre);
        colData.appendChild(contenedorFecha);
        colData.appendChild(contenedorMensaje);
        rowData.appendChild(colData);
        contenedorData.appendChild(rowData);
        contenedorGeneral.appendChild(contenedorImg);
        contenedorGeneral.appendChild(contenedorData);

        document.getElementById("chatList").appendChild(contenedorGeneral);
    }
}

function AddToHtmlChat(arrayModelo) 
{
    for (var i = 0; i < arrayModelo.length; i++) 
    {
        var ultimoMensaje = arrayModelo[i].GetUltimoMensaje();
        var chatMini = arrayModelo[i];

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
        contenedorGeneral.className = "list-group-item list-group-item-action active text-white rounded-0";
        contenedorImg.className = "media";
        imgRecibido.className = "rounded-circle";
        body.className = "media-body ml-4";
        contenedorUser.className = "d-flex align-items-center justify-content-between mb-1";
        nombre.className = "mb-0";
        fecha.className = "small font-weight-bold";
        mensaje.className = "font-italic mb-0 text-small";

        //Add Data
        imgRecibido.alt = "user";
        imgRecibido.width = "50";
        fecha.innerHTML = ultimoMensaje.GetFecha();
        nombre.innerHTML = modelo.GetUserName();
        mensaje.innerHTML = modelo.GetTexto();

        if (modelo.GetUserFoto() != null)
                img.src = chatMini.GetUserFoto();
        else 
            img.src = "";

        contenedorUser.appendChild(nombre);
        contenedorUser.appendChild(fecha);
        body.appendChild(contenedorUser);
        body.appendChild(mensaje);
        contenedorImg.appendChild(img);
        contenedorImg.appendChild(body);
        contenedorGeneral.appendChild(contenedorImg);

        document.getElementById("").appendChild(contenedorGeneral);
    }
}