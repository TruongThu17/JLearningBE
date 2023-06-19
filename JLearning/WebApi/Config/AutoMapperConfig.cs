using AutoMapper;
using BusinessObjects.DTO.Account;
using BusinessObjects.DTO;
using BusinessObjects.Models;

namespace WebApi.Config
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AccountDTO, Account>()
                 .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == 1 ? true : false));

                config.CreateMap<Account, AccountDTO>();

                config.CreateMap<InsertAccountDTO, Account>();
                config.CreateMap<GetAccountDTO, Account>();

                config.CreateMap<BlogDetailDTO, BlogDetail>();
                config.CreateMap<BlogDetail, BlogDetailDTO>();

                config.CreateMap<BlogCategoryDTO, BlogCategory>();
                config.CreateMap<BlogCategory, BlogCategoryDTO>();

                config.CreateMap<BlogDTO, Blog>();
                config.CreateMap<Blog, BlogDTO>().ForMember(dest => dest.BlogDetails, opt => opt.MapFrom(src => src.BlogDetails));

                config.CreateMap<ContactDTO, Contact>();
                config.CreateMap<Contact, ContactDTO>();

                config.CreateMap<FeedbackDTO, Feedback>();
                config.CreateMap<Feedback, FeedbackDTO>();

                config.CreateMap<SupportDTO, Support>();
                config.CreateMap<Support, SupportDTO>();

                config.CreateMap<QuestionDTO, Question>();
                config.CreateMap<Question, QuestionDTO>();

                config.CreateMap<ChapterDTO, Chapter>();
                config.CreateMap<Chapter, ChapterDTO>();
                // more mappings here
            });

            return mapperConfig.CreateMapper();
        }
    }
}
