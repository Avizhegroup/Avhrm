using AutoMapper;
using Avhrm.Domains;

namespace Avhrm.Application.Server.Features;
public class VacationRequestProfile : Profile
{
    public VacationRequestProfile()
    {
        //CreateMap<VacationRequest, InsertVacationRequestCommand>()
        //    .ForMember(dest => dest.PersianFromDate, opt => opt.MapFrom(src => PersianCalendarTools.GregorianToPersian(src.FromDateTime)))
        //    .ForMember(dest => dest.PersianToDate, opt => opt.MapFrom(src => PersianCalendarTools.GregorianToPersian(src.ToDateTime)))
        //    .ForMember(dest => dest.PersianFromTime, opt => opt.MapFrom(src => src.FromDateTime.ToString("HH:mm")))
        //    .ForMember(dest => dest.PersianToTime, opt => opt.MapFrom(src => src.ToDateTime.ToString("HH:mm")));

        CreateMap<InsertVacationRequestCommand, VacationRequest>()
            .ForMember(dest => dest.FromDateTime, opt => opt.MapFrom(src => PersianCalendarTools.PersianToGregorian(src.PersianFromDate)))
            .ForMember(dest => dest.ToDateTime, opt => opt.MapFrom(src => PersianCalendarTools.PersianToGregorian(src.PersianToDate)))
            .ForMember(dest => dest.FromDateTime, opt => opt.MapFrom((src, dest) =>
            {
                var splited = src.PersianFromTime.Split(':');
                return dest.FromDateTime.AddHours(int.Parse(splited[0])).AddMinutes(int.Parse(splited[1]));
            }))
            .ForMember(dest => dest.ToDateTime, opt => opt.MapFrom((src, dest) =>
            {
                var splited = src.PersianToTime.Split(':');
                return dest.ToDateTime.AddHours(int.Parse(splited[0])).AddMinutes(int.Parse(splited[1]));
            }));
    }
}