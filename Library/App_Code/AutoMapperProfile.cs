using AutoMapper;
using Library.Repositories;
using Library.ViewModels;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BookViewModel, Book>();
        CreateMap<Book,BookViewModel>();
    }
}