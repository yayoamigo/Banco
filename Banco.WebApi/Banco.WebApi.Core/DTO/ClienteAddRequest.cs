using Banco.WebApi.Entity;

namespace ServiceContracts.DTO
{
    public class ClienteAddRequest
    {
        public int Identificacion { get; set; }
        public string Contrasena { get; set; } = null!;
        public string? Estado { get; set; } = "Activo";

        public Cliente ToCliente()
        {
            return new Cliente()
            {
                Identificacion = Identificacion,
                Contrasena = Contrasena,
                Estado = Estado
            };
        }
    }
}
