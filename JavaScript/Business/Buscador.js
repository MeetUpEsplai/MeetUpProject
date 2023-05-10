import { GetUsuarioByNombre, GetEventoByNombre } from "../API/ServiceAPI.js";

const searchInput = document.querySelector('.search-container input[type="text"]');
const searchResults = document.querySelector('.search-container .search-results');

searchInput.addEventListener('input', async () => {
    const searchTerm = searchInput.value.trim();
    
    console.log("pasa");
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
    console.log('Resultado seleccionado:', resultId);
    // Aquí puedes hacer algo con el ID del resultado, como redirigir a una página de detalles
    }
});
