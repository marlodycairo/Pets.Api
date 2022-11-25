using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Mascotas.Api.Domain.Models;
using Mascotas.Api.Infrastructure.Entities;

namespace Mascotas.Api.Domain.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pet, PetDto>()
                .ForMember(dest => dest.OwnerDto, opt => opt.MapFrom(src => src.Owner));

            CreateMap<PetDto, Pet>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.OwnerDto));

            CreateMap<Owner, OwnerDto>()
                .ForMember(dest => dest.PetDtos, opt => opt.MapFrom(src => src.Pets));

            CreateMap<OwnerDto, Owner>()
                .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.PetDtos));

            CreateMap<Agenda, AgendaDto>()
                .ForMember(dest => dest.OwnerDto, opt => opt.MapFrom(src => src.Owner))
                .ForMember(dest => dest.PetDto, opt => opt.MapFrom(src => src.Pet));

            CreateMap<AgendaDto, Agenda>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.OwnerDto))
                .ForMember(dest => dest.Pet, opt => opt.MapFrom(src => src.PetDto));

            CreateMap<Rol, RolDto>();
            CreateMap<RolDto, Rol>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<UserRol, UserRolDto>();
            CreateMap<UserRolDto, UserRol>();

            CreateMap<ResponseEntity, ResponseEntityDto>();
            CreateMap<ResponseEntityDto, ResponseEntity>();

            CreateMap<Veterinary, VeterinaryDto>()
                .ForMember(dest => dest.SpecialityDto, opt => opt.MapFrom(src => src.Speciality));

            CreateMap<VeterinaryDto, Veterinary>()
                .ForMember(dest => dest.Speciality, opt => opt.MapFrom(src => src.SpecialityDto));

            CreateMap<Speciality, SpecialityDto>()
                .ForMember(dest => dest.VeterinaryDto, opt => opt.MapFrom(src => src.Veterinary));

            CreateMap<SpecialityDto, Speciality>()
                .ForMember(dest => dest.Veterinary, opt => opt.MapFrom(src => src.VeterinaryDto));

            CreateMap<History, HistoryDto>()
                .ForMember(dest => dest.AgendaDto, opt => opt.MapFrom(src => src.Agenda))
                .ForMember(dest => dest.OwnerDto, opt => opt.MapFrom(src => src.Owner))
                .ForMember(dest => dest.PetDto, opt => opt.MapFrom(src => src.Pet))
                .ForMember(dest => dest.VeterinaryDto, opt => opt.MapFrom(src => src.Veterinary));

            CreateMap<HistoryDto, History>()
                .ForMember(dest => dest.Agenda, opt => opt.MapFrom(src => src.AgendaDto))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.OwnerDto))
                .ForMember(dest => dest.Pet, opt => opt.MapFrom(src => src.PetDto))
                .ForMember(dest => dest.Veterinary, opt => opt.MapFrom(src => src.VeterinaryDto));
        }
    }
}
