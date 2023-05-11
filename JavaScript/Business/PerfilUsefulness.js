import { show, showUser } from "./LocalStorage.js"
import { GetEventoByUsuario, GetUsuarioById } from "../API/ServiceAPI.js"
import { GenerarEventos } from "../Generadores/GenerarEventos.js"
import { CambiarPagina } from "./PageChanger.js";

var idUser = showUser();

console.log("pasa");

GetUsuarioById(idUser).then(user => {
    document.getElementById("nombreCompleto").innerHTML = user.nombre + " " + user.apellido;
    document.getElementById("pNombre").innerHTML = "Nombre: " + user.nombre;
    document.getElementById("pApellido").innerHTML = "Apellido: " + user.apellido;
    document.getElementById("pNacimiento").innerHTML = "Fecha Nacimiento: " + user.fechaNacimiento;
    document.getElementById("pTelefono").innerHTML = "Telefono: 634851855";
    document.getElementById("pEmail").innerHTML = "Email: " + user.email;

    if (user.referenciaFoto != null)
        document.getElementById("imgPerfilInformacionPersonal").src = user.referenciaFoto;
    else 
        document.getElementById("imgPerfilInformacionPersonal").src = "../../imgEventDefault/fotoPerfilDefaul.png";   
});

GetEventoByUsuario(idUser).then(async evento => {
    await GenerarEventos(evento);

    const chats = document.querySelectorAll('.evento');

    console.log(chats);

    AddClickCambiarPagina(chats);
});

function AddClickCambiarPagina(listDivs) {
    listDivs.forEach(div => {
        div.addEventListener('click', () => {
            const id = div.id.split('_')[1];
            CambiarPagina("../../evento/evento.html", idUser, id);
        });
    });
}
