using AutoMapper;
using ZOGLAB.MMMS.Authorization.Users;
using ZOGLAB.MMMS.Authorization.Users.Dto;
using ZOGLAB.MMMS.BD;

namespace ZOGLAB.MMMS
{
    internal static class CustomDtoMapper
    {
        private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();

        public static void CreateMappings(IMapperConfigurationExpression mapper)
        {
            lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal(mapper);

                _mappedBefore = true;
            }
        }

        private static void CreateMappingsInternal(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());

            mapper.CreateMap<BD_Standard, StandardListDto>()
                .ForMember(dto => dto.Installation, opt => opt.MapFrom(src => src.Installation.Equipment_Name))
                .ReverseMap()
                .ForMember(standard => standard.Installation, options => options.Ignore());

            mapper.CreateMap<BD_Standard, StandardEditDto>()
                .ForMember(dto => dto.Installation, opt => opt.MapFrom(src => src.Installation.Equipment_Name))
                .ReverseMap()
                .ForMember(standard => standard.Installation, options => options.Ignore());

            mapper.CreateMap<BD_Receive, ReceiveListDto>()
                .ForMember(dto => dto.UnitName, opt => opt.MapFrom(src => src.Unit.UnitName))
                .ReverseMap();

            mapper.CreateMap<BD_Receive, ReceiveEditDto>()
                .ForMember(dto => dto.UnitName, opt => opt.MapFrom(src => src.Unit.UnitName))
                .ReverseMap()
                .ForMember(src => src.Unit, options => options.Ignore());
        }
    }
}