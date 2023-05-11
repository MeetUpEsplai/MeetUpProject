import { GetUsuarioById } from "../API/ServiceAPI.js"
import { Comentario } from "../Modules/ComentarioClass.js"

export function GenerarComentarios(evento) 
{
    var comentarios = []

    evento.comentarios.forEach(element => {
        comentarios.push(new Comentario(
            element.id,
            element.fechaCreacion,
            element.texto,
            element.texto,
            element.eventoId,
            element.comentarioPadreId
            ))

            console.log("Pasa");
    });
    
    AddToHtml(comentarios);
}


async function AddToHtml(arrayModelo) 
{
    for (var i = 0; i < arrayModelo.length; i++) 
    {
        var comentario = arrayModelo[i];

        var contenedorGeneral = document.createElement("div"),
            contenedorImg = document.createElement("div"),
            img  = document.createElement("img"),
            contenedorData = document.createElement("div"),
            nombreUser = document.createElement("h6"),
            mensaje = document.createElement("comentario");

        //Declaracion de clases e ids
        contenedorGeneral.id = "comentario_" + comentario.GetId();
        contenedorGeneral.className = "row mb-4 divBgPastel cartaComentario";
        contenedorImg.className = "col-2 ms-4 mt-2";
        contenedorImg.id = "divImagenComentarios";
        contenedorData.className = "col-9 mt-2";
        contenedorData.id = "divNombreParrafo";
        nombreUser.id = "nombreUserComentario";

        //Add Data
        await GetUsuarioById(comentario.GetId()).then(x => {
            if (x.referenciaFoto != "")
                img.src = x.referenciaFoto;
            else 
                img.src = "../../imgEventDefault/fotoPerfilDefaul.png";   

            nombreUser.innerHTML = x.nombre;
        });

        mensaje.innerHTML = comentario.GetTexto();

        //Asignar padre
        contenedorImg.appendChild(img);
        contenedorData.appendChild(nombreUser);
        contenedorData.appendChild(mensaje);
        contenedorGeneral.appendChild(contenedorImg);
        contenedorGeneral.appendChild(contenedorData);

        document.getElementById("divCol_comentarios").appendChild(contenedorGeneral);
    }
}