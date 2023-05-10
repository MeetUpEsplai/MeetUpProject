import { GetUsuarioByNombre, GetEventoByNombre } from "../API/ServiceAPI.js";
import { CambiarPagina } from "./PageChanger.js"
import { show, showUser } from "./LocalStorage.js"

const searchInput = document.querySelector('.search-container input[type="text"]');
const searchResults = document.querySelector('.search-container .search-results');

searchInput.addEventListener('input', async () => {
    const searchTerm = searchInput.value.trim();
    
    // Si no hay término de búsqueda, ocultar los resultados
    if (!searchTerm) {
        searchResults.style.display = 'none';
        return;
    }

    var results = [];

    await GetUsuarioByNombre(searchTerm).then(x => {
        x.forEach(element => {
            results.push([element.id, element.nombre, "Usuario"])
        });
    
    });

    await GetEventoByNombre(searchTerm).then(x => {
        x.forEach(element => {
            results.push([element.id, element.nombre, "Evento"])
        });
    });


    // Construir la lista de resultados
    const resultList = results.map(result => `
        <li data-id="${result[0]}">${result[2] + ": "  + result[1]}</li>
    `).join('');

    // Mostrar la lista de resultados
    searchResults.innerHTML = resultList;
    searchResults.style.display = 'block';
});

// Al hacer clic en un resultado, hacer algo con el ID del resultado
searchResults.addEventListener('click', event => {
    const clickedResult = event.target.closest('li');
    if (clickedResult) {
        const resultId = clickedResult.dataset.id;
        var isUser = clickedResult.innerHTML.split(":")[0] == "Usuario";
        if (isUser)
            CambiarPagina("../../perfil/perfil.html", resultId);
        else
            CambiarPagina("../../evento/evento.html", resultId);
    }
});


document.getElementById("tituloMeetUp").addEventListener('click', event => {
    CambiarPagina("../../aplicacion/aplicacion.html", showUser(), null)
});

document.getElementById("btnInicio").addEventListener('click', event => {
    CambiarPagina("../../aplicacion/aplicacion.html", showUser(), null)
});

document.getElementById("btnPerfil").addEventListener('click', event => {
    CambiarPagina("../../perfil/perfil.html", showUser(), showUser())
});

document.getElementById("btnChat").addEventListener('click', event => {
    CambiarPagina("../../chat/chat.html", showUser(), showUser())
});