import { Mensaje } from "../Modules/MensajeClass.js"
import { GetUsuarioById } from "../API/ServiceAPI.js"

export function GenerarMensajes(chat, idUserReg) 
{
    var mensajesModel = []

    chat.mensajes.sort(CompararFechas);

    chat.mensajes.forEach(element => {
        mensajesModel.push(new Mensaje(
            element.id,
            element.fecha,
            element.texto,
            element.chatId,
            element.usuarioId
            ))
    });
    
    AddToHtml(mensajesModel, idUserReg);
}


function CompararFechas(a, b) {
    var fechaA = new Date(a.fecha.replace(/(\d{2})\/(\d{2})\/(\d{4})/, "$2/$1/$3"));
    var fechaB = new Date(b.fecha.replace(/(\d{2})\/(\d{2})\/(\d{4})/, "$2/$1/$3"));
    return fechaA - fechaB;
}

function AddToHtml(arrayModelo, idUserReg) 
{
    for (var i = 0; i < arrayModelo.length; i++) 
    {
        console.log(arrayModelo[i].GetTexto());
        AddUnoToHtml(arrayModelo[i], idUserReg);
    }
}

export function AddUnoToHtml(modelo, idUserReg) 
{
    var contenedorGeneral  = document.createElement("div"),
        body  = document.createElement("div"),
        contentData  = document.createElement("div"),
        mensaje  = document.createElement("p"),
        fecha  = document.createElement("p"),
        imgRecibido  = document.createElement("img");

    //Declaracion de clases y ids html
    contenedorGeneral.className = "media w-50 mb-3 ";
    body.className = "media-body";
    contentData.className = "rounded py-2 px-3 mb-2";
    mensaje.className = "text-small mb-0";
    fecha.className = "small text-muted";

    //Add Data
    mensaje.innerHTML = modelo.GetTexto();
    fecha.innerHTML = modelo.GetFecha();

    
    //Data Dependiente de si es un mensaje recibido o enviado
    if (modelo.GetUsuarioId() != idUserReg)
    {
        body.className += " ml-3";
        contentData.className += " bg-light";
        mensaje.className += " text-muted";
        imgRecibido.className = "rounded-circle";

        imgRecibido.alt = "user";
        imgRecibido.width = "50";

        GetUsuarioById(modelo.GetUsuarioId()).then(x => {
            if (x.referenciaFoto != "")
                imgRecibido.src = x.referenciaFoto ;
            else 
                imgRecibido.src = "../../imgEventDefault/fotoPerfilDefaul.png";
        })

        contenedorGeneral.appendChild(imgRecibido);
    }
    else
    {
        contenedorGeneral.className += "ml-auto";
        contentData.className += " bg-primary";
        mensaje.className += " text-white";
    }


    contentData.appendChild(mensaje);
    body.appendChild(contentData);
    body.appendChild(fecha);
    contenedorGeneral.appendChild(body);

    document.getElementById("listaMensajes").appendChild(contenedorGeneral);
}