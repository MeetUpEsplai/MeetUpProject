import { Mensaje } from "../Modules/MensajeClass.js"
import { GetUsuarioById } from "../API/ServiceAPI.js"

export function GenerarMensajes(mensajes, idUserReg) 
{
    var mensajesModel = []

    mensajes.comentarios.forEach(element => {
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


function AddToHtml(arrayModelo, idUserReg) 
{
    for (var i = 0; i < arrayModelo.length; i++) 
    {
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
    contenedorGeneral.className = "media w-50 mb-3";
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
        contenedorGeneral.className += " ml-auto";
        contentData.className += " bg-primary";
        mensaje.className += " text-white";
        imgRecibido.className = "rounded-circle";

        imgRecibido.alt = "user";
        imgRecibido.width = "50";

        GetUsuarioById(modelo.GetUsuarioId()).then(x => {
            if (x.referenciaFoto != null)
                img.src = x.referenciaFoto ;
            else 
                img.src = "";
        })

        contenedorGeneral.appendChild(imgRecibido);
    }

    contentData.appendChild(mensaje);
    body.appendChild(contentData);
    body.appendChild(fecha);
    contenedorGeneral.appendChild(body);

    document.getElementById("").appendChild(contenedorGeneral);
}