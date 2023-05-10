export function store(data) { localStorage.setItem("data", data); } 

export function storeUser(idUser) { localStorage.setItem("user", idUser); } 

export function show() { return localStorage.getItem("data"); }

export function showUser() { return localStorage.getItem("user"); }