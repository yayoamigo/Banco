﻿using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.WebApi.Core.ServiceContracts
{
    public interface IClienteAdderService
    {
        Task<ClienteResponse> AddCliente(ClienteAddRequest request);
    }
}
