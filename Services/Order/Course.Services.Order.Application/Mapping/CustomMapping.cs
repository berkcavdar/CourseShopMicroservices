﻿using AutoMapper;
using Course.Services.Order.Application.Dtos;
using Course.Services.Order.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Services.Order.Application.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Order.Domain.OrderAggregate.Order,OrderDto>().ReverseMap();
            CreateMap<OrderItem,OrderItemDto>().ReverseMap();
            CreateMap<Address,AddressDto>().ReverseMap();   
        }
    }
}
