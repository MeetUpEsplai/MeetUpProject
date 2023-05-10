import { Usuario } from "../Modules/UsuarioClass.js"

export function GenerarUsuarios(usuarios) 
{
    var usuariosModel = []

    usuarios.comentarios.forEach(element => {
        usuariosModel.push(new Usuario(
            element.id,
            element.nombre,
            element.nombre,
            element.email,
            element.password,
            element.fechaNacimiento,
            element.referenciaFoto
            ))
    });
    
    AddToHtml(usuariosModel);
}


function AddToHtml(arrayModelo) 
{
    for (var i = 0; i < arrayModelo.length; i++) 
    {
        var usuario = arrayModelo[i];

        var contenedorGeneral  = document.createElement("div"),
            row  = document.createElement("div"),
            col  = document.createElement("div"),
            img  = document.createElement("img"),
            nombreUser  = document.createElement("h5");

        //Declaracion de clases e ids
        contenedorGeneral.id = "user_" + usuario.GetId();
        contenedorGeneral.class = "col-2 cardAsistente divBgPastel";
        row.class = "row";
        row.id = "divRow_imagenAsistente";
        col.class = "col-2 centrarContenidoCarta";

        //Add Data
        if (usuario.GetRefereciaFoto() != null)
                img.src = usuario.GetRefereciaFoto();
        else 
            img.src = "";

        nombreUser.innerHTML = usuario.GetNombre() + usuario.GetApellido();

        //Asignar padre
        col.appendChild(img);
        col.appendChild(nombreUser);
        row.appendChild(col);
        contenedorGeneral.appendChild(row);

        document.getElementById("divRow_contenidoAsistentes").appendChild(contenedorGeneral);
    }
}