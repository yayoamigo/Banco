using System;
using System.ComponentModel.DataAnnotations;
using Banco.WebApi.Entity;

namespace ServiceContracts.DTO
{
    
    public class ClienteUpdateRequest
    {
        [Required(ErrorMessage = "Cliente ID can't be blank")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Identificación can't be blank")]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "Contraseña can't be blank")]
        public string Contrasena { get; set; }

        public string? Estado { get; set; } = "Activo";

       
        public Cliente ToCliente()
        {
            return new Cliente() { ClienteId = ClienteId, Identificacion = Identificacion, Contrasena = Contrasena, Estado = Estado ?? "Activo" };
        }
    }
}
