import { store, storeUser } from "./LocalStorage.js"

export function CambiarPagina(ruta, userId, data) 
{
    storeUser(userId);
    if (data != null)
        store(data);
        
    window.location.href = ruta;
}