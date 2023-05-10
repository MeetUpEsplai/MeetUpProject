import { GetUsuarioByEmail, PostUsuario } from "../API/ServiceAPI.js";
import { Usuario } from "../Modules/UsuarioClass.js"
import { CambiarPagina } from "../Business/PageChanger.js"



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
                CambiarPagina("../../aplicacion/aplicacion.html", user.id);
            else
            {
                //Mensaje Error
                console.log("Error");
            }
        }
    });
});



document.getElementById("btnEnviar").addEventListener('click', event => 
{
    var email = document.getElementById("emailSecundario").value;

    console.log(email);

    GetUsuarioByEmail(email).then(async user => 
    {
        if (user.status == "404")
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
                    CambiarPagina("../../aplicacion/aplicacion.html", user.id);
                });
            }
        }
        else
            //Mensaje Error
            console.log("Error");
    });
});


