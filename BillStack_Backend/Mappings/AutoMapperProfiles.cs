using AutoMapper;
using BillStack_Backend.Models.Domains;
using BillStack_Backend.Models.DTO;

namespace BillStack_Backend.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateBillDto, Bill>().ReverseMap();
            CreateMap<Bill, ObtainBillDto>().ReverseMap();
            CreateMap<UpdateBillDto, Bill>().ReverseMap();
            CreateMap<UpdateBillStateDto, Bill>().ReverseMap();
        }
    }
}
