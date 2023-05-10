import { show, showUser } from "./LocalStorage.js"
import { GetEventoById } from "../API/ServiceAPI.js"

var idUserRegistrado = showUser();
var idUser = showUser();
var idUser = 1;

GetEventoById(idUser).then(user => {
    document.getElementById("pNombre").innerHTML = user.nombre;
    document.getElementById("pApellido").innerHTML = user.apellido;
    document.getElementById("pNacimiento").innerHTML = user.fechaNacimiento;
    document.getElementById("pTelefono").innerHTML = "722890009";
    document.getElementById("pEmail").innerHTML = user.email;

    if (user.referenciaFoto != null)
        document.getElementById("imgPerfilInformacionPersonal").src = user.referenciaFoto;
    else 
        document.getElementById("imgPerfilInformacionPersonal").src = "../../imgEventDefault/fotoPerfilDefaul.png";   
});