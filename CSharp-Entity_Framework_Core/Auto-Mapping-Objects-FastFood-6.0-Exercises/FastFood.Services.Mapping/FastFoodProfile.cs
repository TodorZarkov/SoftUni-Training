namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Models;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, 
                y => y.MapFrom(s => s.PositionName));

            CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, 
                y => y.MapFrom(s => s.Name));

            //Categories
            CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(d => d.Name, 
                opt => opt.MapFrom(s => s.CategoryName));

            CreateMap<Category, CategoryAllViewModel>();

            //Items
            CreateMap<Category, CreateItemViewModel>()
                .ForMember(d => d.CategoryId, 
                    opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CategoryName,
                    opt => opt.MapFrom(s => s.Name));

            CreateMap<CreateItemInputModel, Item>()
                .ForMember(d => d.Name,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Price,
                    opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.CategoryId,
                    opt => opt.MapFrom(s => s.CategoryId));

            CreateMap<Item, ItemsAllViewModels>()
                .ForMember(d => (object)d.Category,
                    opt => opt.MapFrom(s => s.Category.Name));
        }
    }
}
