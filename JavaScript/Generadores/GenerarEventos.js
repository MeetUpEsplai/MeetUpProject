export function GenerarEventos(arrayModelo) 
{
    for (var i = 0; i < arrayModelo.length; i++) 
    {
        modelo = arrayModelo[i].GetEvento();
        count = arrayModelo[i].GetCount();

        var row = document.createElement("div"),
            containerImg = document.createElement("div"),
            img = document.createElement("img"),
            containerData = document.createElement("div"),
            fecha = document.createElement("h5"),
            titulo = document.createElement("h5"),
            descripcion = document.createElement("h5"),
            numAsistentes = document.createElement("h5");

            //Declaracion de clases html
            row.className = "row";
            containerImg.className = "col-4";
            img.className = "rounded-3";
            containerData = "col-8 text-white";

            //Add Data
            img.src = modelo.GetFotoPrincipal();
            fecha = modelo.GetFechaEvento();
            titulo = modelo.GetNombre();
            descripcion = modelo.GetDescripcion();
            numAsistentes = count + " asistentes";

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