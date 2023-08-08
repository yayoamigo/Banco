using Banco.WebApi.Entity;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class ClienteAddRequest
    {
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int Identificacion { get; set; }
        [Required]
        public string Contrasena { get; set; } = null!;
        public string? Estado { get; set; } = "A";

        public Cliente ToCliente()
        {
            return new Cliente()
            {
                ClienteId = ClienteId,
                Identificacion = Identificacion,
                Contrasena = Contrasena,
                Estado = Estado
            };
        }
    }
}
