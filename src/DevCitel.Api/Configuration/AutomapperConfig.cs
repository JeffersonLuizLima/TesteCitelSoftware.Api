using AutoMapper;
using DevCitel.Api.ViewModels;
using DevCitel.Business.Models;

namespace DevCitel.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
