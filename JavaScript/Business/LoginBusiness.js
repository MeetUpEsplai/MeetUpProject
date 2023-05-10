import { GetUsuarioByEmail, PostUsuario } from "../API/ServiceAPI.js";
import { Usuario } from "../Modules/UsuarioClass.js"

console.log("pasa");

function CambiarPagina(userId) 
{
    console.log("CambiarPagina");
    //Cambiar pagina con user id
}

function CheckRegisterOk(nombre, apellido, psswrd, psswrdRepetida, fecha) 
{
    return nombre != "" &&
        apellido != "" &&
        psswrd != "" &&
        fecha != "" &&
        psswrd == psswrdRepetida;
}

document.getElementById("btnLogin").addEventListener('click', event => 
{
    var email = document.getElementById("emailPrincipal").value;
    GetUsuarioByEmail(email).then(user => {
        if (user != null)
        {
            var contrasena = document.getElementById("pswPrincipal").value;
            if (user.password == contrasena)
                CambiarPagina(user.id);
            else
            {
                //Mensaje Error
                console.log("Error");
            }
        }
    });
});



document.getElementById("btnRegistrarse").addEventListener('click', event => 
{
    var email = document.getElementById("emailSecundario").value;
    GetUsuarioByEmail().then(async user => 
    {
        if (user == null)
        {
            var nombre = document.getElementById("nombre").value;
            var apellido = document.getElementById("apellido").value;
            var psswrd = document.getElementById("pswSecundario").value;
            var psswrdRepetida = document.getElementById("pswRepeat").value;
            var fecha = document.getElementById("pick-date").value;
            
            console.log(psswrd);
            console.log(fecha);

            if (CheckRegisterOk(nombre, apellido, psswrd, psswrdRepetida, fecha)) 
            {
                await PostUsuario(new Usuario(0, nombre, apellido, email, psswrd, fecha, null))
                GetUsuarioByEmail(email).then(user => 
                {
                    
                    CambiarPagina(user.id);
                });
            }
        }
        else
            //Mensaje Error
            console.log("Error");
    });
});


