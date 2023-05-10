import { GetEventoById } from "../API/ServiceAPI.js"
import { show } from "./LocalStorage.js"

GetEventoById(1).then(evento => {
    document.getElementById("parrafoDetalles").innerText = evento.descripcion;
    document.getElementById("parrafoHorario").innerText = evento.fechaEvento;
    document.getElementById("ubicacionGeneral").innerText = evento.ciudadProxima;
    document.getElementById("parrafoUbicacion").innerText = evento.coordenadas;
    
});