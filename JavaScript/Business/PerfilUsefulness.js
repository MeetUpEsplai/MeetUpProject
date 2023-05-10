import { show, showUser } from "./LocalStorage.js"
import { GetEventoById } from "../API/ServiceAPI.js"

var idUserRegistrado = showUser();
var idUser = showUser();
var idUser = 1;

GetEventoById(idUser).then(user => {
    document.getElementById("nombreUser").innerHTML = user.nombre;
    document.getElementById("appelidoUSer").innerHTML = user.apellido;
    document.getElementById("fechaUser").innerHTML = user.fechaNacimiento;
    document.getElementById("telUser").innerHTML = "722890009";
    document.getElementById("emailUser").innerHTML = user.email;

    if (user.referenciaFoto != null)
        document.getElementById("fotoUser").src = user.referenciaFoto;
    else 
        document.getElementById("fotoUser").src = "../../imgEventDefault/fotoPerfilDefaul.png";   
});