using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

internal class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<TransactionEntity, Transaction>();
        CreateMap<TransactionEntity, Transaction>().ReverseMap();
    }
}
