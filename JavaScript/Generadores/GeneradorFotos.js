import { Foto } from "../Modules/FotoClass.js"

export function GenerarFotos(evento) 
{
    var fotosModel = []

    evento.fotos.forEach(element => {
        fotosModel.push(new Foto(
            element.id,
            element.referencia,
            element.referencia,
            ))
    });
    
    AddToHtml(fotosModel);
}


function AddToHtml(arrayModelo) 
{
    for (var i = 0; i < arrayModelo.length; i++) 
    {
        var imgModelo = arrayModelo[i];

        var img  = document.createElement("img");

        //Declaracion de clases e ids
        img.className = "cardFoto";

        //Add Data
        img.src = imgModelo.GetReferencia();

        //Asignar padre
        document.getElementById("divRow_contenidoFotos").appendChild(img);
    }
}