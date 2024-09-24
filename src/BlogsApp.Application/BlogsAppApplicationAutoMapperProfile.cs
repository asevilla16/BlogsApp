using AutoMapper;
using BlogsApp.Categories;
using BlogsApp.Entries;

namespace BlogsApp;

public class BlogsAppApplicationAutoMapperProfile : Profile
{
    public BlogsAppApplicationAutoMapperProfile()
    {
        CreateMap<Entry, EntryDto>();
            //.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();
        CreateMap<CreateUpdateEntryDto, Entry>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
