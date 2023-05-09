import { GetAllEvento, GetEventoCountSuscritos } from "../API/ServiceAPI.js";

export async function GenerarEventos(listEventos) 
{
    var eventosContent = [];

    for (var i = 0; i < listEventos.length; i++) 
    {
    var actual = result[i];
    
        var evento = new Evento(
            actual.id, 
            actual.nombre,
            actual.fechaEvento,
            actual.precio,
            actual.descripcion,
            actual.coordenadas,
            actual.ciudadProxima,
            actual.referenciaFotoPrincipaSl,
            actual.usuarioId,
            null)
    
            await GetEventoCountSuscritos(evento.id).then((result) => {
                eventosContent.push(new EventoContent(evento, result + 1))
            });
    }
    
    AddToHtml(eventosContent);
}


function AddToHtml(arrayModelo) 
{
    for (var i = 0; i < arrayModelo.length; i++) 
    {
        var modelo = arrayModelo[i].GetEvento();
        var count = arrayModelo[i].GetCount();

        var row = document.createElement("div"),
            containerImg = document.createElement("div"),
            img = document.createElement("img"),
            containerData = document.createElement("div"),
            fecha = document.createElement("h5"),
            titulo = document.createElement("h5"),
            descripcion = document.createElement("h5"),
            numAsistentes = document.createElement("h5");

            //Declaracion de clases y ids html
            row.id = "evento_" + modelo.GetId();
            row.className = "row evento";
            containerImg.className = "col-4";
            img.className = "rounded-3";
            containerData.className  = "col-8 text-white";

            //Add Data
            if (modelo.GetFotoPrincipal() != null)
                img.src = modelo.GetFotoPrincipal();
            else 
                img.src = "";
                
            fecha.innerHTML = modelo.GetFechaEvento();
            titulo.innerHTML = modelo.GetNombre();
            descripcion.innerHTML = modelo.GetDescripcion();
            numAsistentes.innerHTML = count + " asistentes";
            
            //Asignar padre
            containerImg.appendChild(img);
            containerData.appendChild(fecha);
            containerData.appendChild(titulo);
            containerData.appendChild(descripcion);
            containerData.appendChild(numAsistentes);
            row.appendChild(containerImg);
            row.appendChild(containerData);

            document.getElementById("eventosList").appendChild(row);
    }
}