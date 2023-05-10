import { Foto } from "../Modules/FotoClass.js"

export function GenerarFotos(fotos) 
{
    var fotosModel = []

    fotos.comentarios.forEach(element => {
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
        img.class = "cardFoto";

        //Add Data
        img.src = imgModelo.GetReferencia();

        //Asignar padre
        document.getElementById("divRow_contenidoFotos").appendChild(contenedorGeneral);
    }
}