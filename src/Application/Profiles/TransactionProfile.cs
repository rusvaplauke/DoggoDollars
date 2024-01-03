using AutoMapper;
using Domain.Entities;
using Application.Dtos;

namespace Application.Profiles;

internal class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<TransactionEntity, Transaction>();
        CreateMap<TransactionEntity, Transaction>().ReverseMap();

        CreateMap<TransactionEntity, TransactionRequest>()
            .ForMember(req => req.ReceiverAccount, opt => opt.MapFrom(ent => ent.CorrespondingAccount))
            .ForMember(req => req.SenderAccount, opt => opt.MapFrom(ent => ent.Account));
        CreateMap<TransactionRequest, TransactionEntity>()
            .ForMember(ent => ent.CorrespondingAccount, opt => opt.MapFrom(req => req.ReceiverAccount))
            .ForMember(ent => ent.Account, opt => opt.MapFrom(req => req.SenderAccount));
    }
}
