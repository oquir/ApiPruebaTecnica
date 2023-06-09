﻿using Microsoft.AspNetCore.Mvc;
using pruebaApiFinal.ConexionSQL;
using pruebaApiFinal.Modelos;

namespace pruebaApiFinal.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        ConexionCliente Usuario = new ConexionCliente();

        [HttpGet]
        [Route("/MostrarUsuarios")]
        public List<Usuario> MostrarUsuarios()
        {
            return Usuario.MostrarUsuarios();
        }

        [HttpPost]
        [Route("/AgregarUsuario")]
        public string AgregarUsuario(Usuario User)
        {
            var respuesta = Usuario.AgregarUsuario(User);
            return respuesta;
        }

        [HttpPost]
        [Route("/CambiarUsuario")]
        public string CambiarUsuario(Usuario User)
        {
            var respuesta = Usuario.CambiarUsuario(User);
            return respuesta;
        }

        [HttpPost]
        [Route("/EliminarUsuarios")]
        public string EliminarUsuarios()
        {
            var Respuesta = Usuario.EliminarUsuarios();
            return Respuesta;
        }

        [HttpPost]
        [Route("/EliminarUsuarioUnico")]
        public string EliminarUsuariosUnico(int Id)
        {
            var Respuesta = Usuario.EliminarUsuarioUnico(Id);
            return Respuesta;
        }

    }
}
