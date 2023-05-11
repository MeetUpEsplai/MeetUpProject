import { show, showUser} from "../../JavaScript/Business/LocalStorage.js"
import { PostReaccionEventos } from "../../JavaScript/API/ServiceAPI.js"
import { UsuarioReaccionaeEvento } from "../../JavaScript/Modules/UsuarioReaccionaEventoClass.js"

document.getElementById("gusta").addEventListener('click', () => {    
    MandarDatos(3);
    document.getElementById('tituloReaccion').innerHTML='Me Gusta';
});

document.getElementById("encanta").addEventListener('click', () => {
    MandarDatos(2);
    document.getElementById('tituloReaccion').innerHTML='Me Encanta';
});

document.getElementById("divierte").addEventListener('click', () => {
    MandarDatos(5);
    document.getElementById('tituloReaccion').innerHTML='Me Divierte';
});

document.getElementById("asombra").addEventListener('click', () => {
    MandarDatos(1);
    document.getElementById('tituloReaccion').innerHTML='Me Asombra';
});

document.getElementById("entristece").addEventListener('click', () => {
    MandarDatos(6);
    document.getElementById('tituloReaccion').innerHTML='Me Entristece';
});

document.getElementById("enoja").addEventListener('click', () => {
    MandarDatos(4);
    document.getElementById('tituloReaccion').innerHTML='Me Enfada';
});

function MandarDatos(intId) {
    var reaccion = new UsuarioReaccionaeEvento(show(), showUser(), intId);
    PostReaccionEventos(reaccion);
    var num = parseInt(document.getElementById('tituloReaccion').innerHTML) + 1;
    document.getElementById('tituloReaccion').innerHTML = num;
}