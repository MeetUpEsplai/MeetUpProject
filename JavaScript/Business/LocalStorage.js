export function store(data) { localStorage.setItem("storage", data); };   

export function show() { return localStorage.getItem("storage"); };