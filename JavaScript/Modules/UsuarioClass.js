export class Usuario {
    constructor(id, nombre, apellido, email, contrasena, fechaNacimiento, referenciaFoto) 
    {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.email = email;
        this.contrasena = contrasena;
        this.fechaNacimiento = fechaNacimiento;
        this.referenciaFoto = referenciaFoto
    }

    GetId() { return this.id }
    GetNombre() { return this.nombre; }
    GetApellido() { return this.apellido; }
    GetEmail() { return this.email; }
    GetContrasena() { return this.contrasena; }
    GetFechaNacimiento() { return this.fechaNacimiento; }
    GetRefereciaFoto() { return this.referenciaFoto; }
}