using System;
using System.Collections.Generic;
using Banco.WebApi.Entity;

namespace ServiceContracts.DTO
{
    public class ClienteResponse
    {
        public int ClienteId { get; set; }
        public int Identificacion { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(ClienteResponse)) return false;
            ClienteResponse cliente_to_compare = (ClienteResponse)obj;
            return ClienteId == cliente_to_compare.ClienteId && Identificacion == cliente_to_compare.Identificacion;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class ClienteExtensions
    {
        public static ClienteResponse ToClienteResponse(this Cliente cliente)
        {
            return new ClienteResponse() { ClienteId = cliente.ClienteId, Identificacion = cliente.Identificacion };
        }
    }
}
