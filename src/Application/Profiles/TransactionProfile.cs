using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Profiles;

internal class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<TransactionEntity, Transaction>();
        CreateMap<TransactionEntity, Transaction>().ReverseMap();
    }
}
