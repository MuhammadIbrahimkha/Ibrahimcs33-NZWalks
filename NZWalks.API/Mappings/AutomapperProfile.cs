using AutoMapper;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;
using System.Security.Principal;

namespace NZWalks.API.Mappings
{
    public class AutomapperProfile : Profile
    {


        public AutomapperProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequest_DTO,Region>().ReverseMap();
            CreateMap<UpdateRegion_DTO,Region>().ReverseMap();
            CreateMap<AddWalkRequest_DTO, Walk>().ReverseMap();
            CreateMap<Walk,WalkDto>().ReverseMap();
            CreateMap<Difficulty,DifficultyDto>().ReverseMap();

        }



        // This is just for the below classes for demostration how it works.
        //public AutomapperProfile()
        //{
        //    CreateMap<UserDto, UserDomain>()
        //        .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.Name))
        //        .ReverseMap();
        //}
    }


    //public class UserDto
    //{
    //    public string Name { get; set; }
    //}

    //// At this time the property does not match the property in the UserDto class, so it will not be mapped.
    //public class UserDomain
    //{
    //    public string FullName { get; set; }

    //}
}
