import { store } from "./LocalStorage.js"

export function CambiarPagina(ruta, datos) 
{
    store(datos);
    window.location.href = ruta;
}