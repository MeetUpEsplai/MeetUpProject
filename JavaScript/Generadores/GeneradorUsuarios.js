import { Usuario } from "../Modules/UsuarioClass.js"

export function GenerarUsuarios(usuarios) 
{
    var usuario = new Usuario(
        usuarios.id,
        usuarios.nombre,
        usuarios.apellido,
        usuarios.email,
        usuarios.password,
        usuarios.fechaNacimiento,
        usuarios.referenciaFoto
        )
    
    AddToHtml(usuario);
}

function AddToHtml(arrayModelo) 
{
        var usuario = arrayModelo;

        var contenedorGeneral = document.createElement("div"),
            row  = document.createElement("div"),
            col  = document.createElement("div"),
            img  = document.createElement("img"),
            nombreUser  = document.createElement("h5");

        //Declaracion de clases e ids
        contenedorGeneral.id = "user_" + usuario.GetId();
        contenedorGeneral.className = "col-2 cardAsistente divBgPastel userEtiqueta";
        row.className = "row";
        row.id = "divRow_imagenAsistente";
        col.className = "col-2 centrarContenidoCarta";

        //Add Data
        if (usuario.GetRefereciaFoto() != "")
            img.src = usuario.GetRefereciaFoto();
        else 
            img.src = "";

        nombreUser.innerHTML = usuario.GetNombre() + " " + usuario.GetApellido();

        //Asignar padre
        col.appendChild(img);
        col.appendChild(nombreUser);
        row.appendChild(col);
        contenedorGeneral.appendChild(row);

        document.getElementById("divRow_contenidoAsistentes").appendChild(contenedorGeneral);
}