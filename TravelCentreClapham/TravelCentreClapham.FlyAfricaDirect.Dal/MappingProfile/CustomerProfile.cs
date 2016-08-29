﻿using AutoMapper;
using NexusCore.Infrastructure.Mappers;
using TravelCentreClapham.FlyAfricaDirect.Dal.Entities;
using TravelCentreClapham.FlyAfricaDirect.Dal.Models;

namespace TravelCentreClapham.FlyAfricaDirect.Dal.MappingProfile
{
    public class CustomerProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Customer, CustomerDto>().IgnoreAllMissingInTarget();
            Mapper.CreateMap<CustomerDto, Customer>().IgnoreAllMissingInTarget();
        }
    }
}