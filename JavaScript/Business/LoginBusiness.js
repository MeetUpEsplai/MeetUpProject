import { GetUsuarioByEmail, PostUsuario } from "../API/ServiceAPI.js";
import { Usuario } from "../Modules/UsuarioClass.js"


function CambiarPagina(userId) 
{
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

document.getElementById("ProvisionalBotonLogin").onclick(x => 
{
    var email = document.getElementById("emailLogin").innerHTML;
    console.log(email);
    GetUsuarioByEmail(email).then(user => {
        if (user != null)
            {
        var contrasena = document.getElementById("psswrLogin").innerHTML;
        if (user.GetContrasena() == contrasena)
            CambiarPagina(user.GetId());
        else
            //Mensaje Error
            console.log("Error");
        }
    });
});


document.getElementById("ProvisionalBotonRegister").onclick(async x => 
{
    var email = document.getElementById("emailLogin").innerHTML;
    GetUsuarioByEmail().then(async user => 
    {
        if (user == null)
        {
            var nombre = document.getElementById("placeholder").innerHTML;
            var apellido = document.getElementById("placeholder").innerHTML;
            var psswrd = document.getElementById("placeholder").innerHTML;
            var psswrdRepetida = document.getElementById("placeholder").innerHTML;
            var fecha = document.getElementById("placeholder").innerHTML;

            if (CheckRegisterOk(nombre, apellido, psswrd, psswrdRepetida, fecha)) 
            {
                await PostUsuario(new Usuario(0, nombre, apellido, email, psswrd, fecha, null))
                GetUsuarioByEmail(email).then(user => 
                {
                    CambiarPagina(user.GetId());
                });
            }
        }
        else
            //Mensaje Error
            console.log("Error");
    });
});


