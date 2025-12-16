using System;
using Application.DTO;
using Application.Users.Commands.DTO;
using AutoMapper;
using Domain.DBSchemas;

namespace Application.Core;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<CreateItemDTO, Items>();
		CreateMap<RegisterUserDTO, User>();
		CreateMap<CreateOrderDTO, OrderItems>();
	}
}
