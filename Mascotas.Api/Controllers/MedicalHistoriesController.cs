using Mascotas.Api.Application;
using Mascotas.Api.Domain.Models;
using Mascotas.Api.Domain.QueryFiltersModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mascotas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoriesController : ControllerBase
    {
        private readonly IVeterinaryApplication veterinary;
        private readonly IPetApplication pet;
        private readonly IOwnerApplication owner;
        private readonly IAgendaApplication agenda;

        public MedicalHistoriesController(IVeterinaryApplication veterinary, IPetApplication pet,
            IOwnerApplication owner, IAgendaApplication agenda)
        {
            this.veterinary = veterinary;
            this.pet = pet;
            this.owner = owner;
            this.agenda = agenda;
        }

        [HttpGet]
        public async Task<IActionResult> GetMedicalHistories()
        {
            //RangeMethod
            IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);

            foreach (int num in squares)
            {
                Console.WriteLine(num);
            }

            var pets = await pet.GetAllPets();
            var owners = await owner.GetAllOwner();

            ////OfTypeMethod
            //IEnumerable<PetDto> queryOfType = pets.OfType<PetDto>().Where(p => p.Name.ToLower().Contains(p.Name = "titan".ToLower()));

            //List<PetDto> resultOfType = new List<PetDto>();

            //foreach (var item in queryOfType)
            //{
            //    resultOfType.Add(item);
            //}

            ////ReverseMethod Invierte el orden de la secuencia
            //var reversePets = pets.Reverse().ToList();

            ////SkipMethod Omite 2 elementos al inicio de la secuencia o consulta.
            //var lstPets = pets.OrderBy(p => p.Id).Skip(2);

            ////SkipLastMethod Omite 2 elementos al final de la secuencia. Es decir muestra todos los registros excepto los ultimos 2.
            //var lstPets = pets.OrderBy(p => p.Id).SkipLast(2);

            //var lstPets = pets.OrderBy(p => p.Id).SkipWhile(p => p.Race == "Angora_Turco");

            string[] petNames = pets.Select(p => p.Name).ToArray();
            return Ok(petNames);
        }
    }
}
