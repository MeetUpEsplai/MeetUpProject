export class Usuario {
    constructor(nombre, apellido, email, contrasena, fechaNacimiento) {
        this.nombre = nombre;
        this.apellido = apellido;
        this.email = email;
        this.contrasena = contrasena;
        this.fechaNacimiento = fechaNacimiento;
    }

    GetNombre() { return this.nombre; }
    GetApellido() { return this.apellido; }
    GetEmail() { return this.email; }
    GetContrasena() { return this.contrasena; }
    GetFechaNacimiento() { return this.fechaNacimiento; }
}