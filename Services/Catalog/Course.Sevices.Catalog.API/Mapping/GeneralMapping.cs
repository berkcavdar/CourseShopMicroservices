using AutoMapper;
using Course.Sevices.Catalog.API.Dtos;
using Course.Sevices.Catalog.API.Models;

namespace Course.Sevices.Catalog.API.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //Entities Mapping
            CreateMap<Models.Course, CourseDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Feature,FeatureDto>().ReverseMap();

            //CourseInsert Mapping
            CreateMap<Models.Course,CourseInsertDto>().ReverseMap();
            CreateMap<Models.Course, CourseUpdateDto>().ReverseMap();
        }
    }
}
