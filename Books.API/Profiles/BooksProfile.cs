using AutoMapper;

namespace Books.API.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Entities.Book, Models.Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(
                    src => src.Id))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(
                    src => $"{src.Author.FirstName} {src.Author.LastName}"))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(
                    src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(
                    src => src.Description));

            CreateMap<Models.BookForCreation, Entities.Book>();
        }
    }
}
