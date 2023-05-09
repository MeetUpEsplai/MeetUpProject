import { ChatMini } from "../Modules/ChatClass.js"

export function GenerarChats(usuario) 
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
    
    AddToHtml(eventosContent);
}


function AddToHtml(arrayModelo) 
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