using AutoMapper;
using ContactMgmt.Api.Models;
using ContactMgmt.DbManager;
using TagValue = ContactMgmt.Api.Models.TagValue;

namespace ContactMgmt.Api.App_Start
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            Mapper.CreateMap<Contact, BasicContactInformation>()
                .ForMember(x => x.ContactId, y => y.MapFrom(src => src.Contacts_Id));

            Mapper.CreateMap<DbManager.TagValue, TagValue>()
                .ForMember(x => x.TagTypeId, y => y.MapFrom(src => src.TagType_Id))
                .ForMember(x => x.TagName, y => y.MapFrom(src => src.TagType.TagName))
                .ForMember(x => x.Value, y => y.MapFrom(src => src.Value));

            Mapper.CreateMap<Contact, FullContactInformation>()
                .ForMember(x=> x.TagValues, y => y.MapFrom(src => src.TagValues))
                .ForMember(x => x.ContactId, y => y.MapFrom(src => src.Contacts_Id));

            Mapper.CreateMap<TagType, TagConfig>()
                .ForMember(x => x.TagTypeId, y => y.MapFrom(src => src.TagType_Id))
                .ForMember(x => x.ValidatorRegEx, y => y.MapFrom(src => src.ValidatorRegEx));   //TODO - Why AutoMapper does not work, why explicit mapping: perhaphs an investigation for some other day

        }
    }
}