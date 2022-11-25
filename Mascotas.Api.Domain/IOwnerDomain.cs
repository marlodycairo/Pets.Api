using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Domain
{
    public interface IOwnerDomain
    {
        Task<OwnerDto> AddOwner(OwnerDto owner);
    }
}
