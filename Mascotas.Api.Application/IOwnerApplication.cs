using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mascotas.Api.Application
{
    public interface IOwnerApplication
    {
        Task<OwnerDto> AddOwner(OwnerDto owner);
    }
}
