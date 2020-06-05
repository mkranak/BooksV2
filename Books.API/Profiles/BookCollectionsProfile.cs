using AutoMapper;
using Books.API.Models;
using System.Collections.Generic;

namespace Books.API.Profiles
{
    public class BookCollectionsProfile : Profile
    {
        public BookCollectionsProfile()
        {
            CreateMap<IEnumerable<BookForCreation>, IEnumerable<Book>>();
        }
    }
}
