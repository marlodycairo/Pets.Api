using FluentValidation;
using Mascotas.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Domain.Validations
{
    public class PetValidator : AbstractValidator<PetDto>
    {
        public PetValidator()
        {
            RuleFor(p => p.Name).NotNull()
                .NotEmpty().WithMessage("Ingrese el nombre de la mascota.");

            RuleFor(p => p.Race).NotNull()
                .NotEmpty().WithMessage("Debe ingresar la raza de la mascota");

            RuleFor(p => p.Born.ToShortDateString())
                .NotEmpty().WithMessage("Ingrese la fecha de nacimiento de su mascota");

            RuleFor(p => p.OwnerId).NotNull()
                .NotEmpty().WithMessage("Debe incluir información del propietario.");

            RuleFor(p => p.PetTypes).NotNull()
                .NotEmpty().WithMessage("Debe seleccionar el tipo de mascota.");

            RuleFor(p => p.Photo).NotNull()
                .NotEmpty().WithMessage("Debe seleccionar la foto de la mascota.");
        }
    }
}
