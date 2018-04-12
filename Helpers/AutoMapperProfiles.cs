using System.Collections.Generic;
using System.Linq;
using app.Data;
using app.Models;
using app.View;
using AutoMapper;

namespace app.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
           
           
            CreateMap<Users, UserForList>()
              .ForMember(dest => dest.PhotoUrl, opt =>
              {
                  opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
              })
              .ForMember(dest => dest.Mosha, opt =>
              {
                  opt.ResolveUsing(d => d.Datelindja.CalculateAge());
              })
              .ForMember(dest => dest.Roli, opt =>
              {
                  opt.MapFrom(src => src.Role.Role);
              });
             

            CreateMap<Users, UserForDetail>()
            .ForMember(dest => dest.PhotoUrl, opt =>
              {
                  opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
              })
              .ForMember(dest => dest.Mosha, opt =>
              {
                  opt.ResolveUsing(d => d.Datelindja.CalculateAge());
              })
              .ForMember(dest => dest.Roli, opt =>
              {
                  opt.MapFrom(src => src.Role.Role);
              });
            CreateMap<Photos, PhotoForDetail>();
        }
    }
}