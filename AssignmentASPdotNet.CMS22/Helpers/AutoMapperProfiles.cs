using AssignmentASPdotNet.CMS22.Models;
using AssignmentASPdotNet.CMS22.Models.Entities;
using AutoMapper;

namespace AssignmentASPdotNet.CMS22.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<NavLinkEntity, NavlinkModel>().ReverseMap();
            CreateMap<ImageEntity, ImageModel>().ReverseMap();
            CreateMap<ShowcaseEntity, ShowcaseModel>().ReverseMap();
            CreateMap<ProductReviewModel, ProductReviewEntity>().ReverseMap();
        }
    }
}
