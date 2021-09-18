using AutoMapper;
using DevCitel.Api.Controllers;
using DevCitel.Api.ViewModels;
using DevCitel.Business.Intefaces;
using DevCitel.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevCitel.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/categorias")]
    public class CategoriasController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriasController(INotificador notificador,
                                    ICategoriaRepository categoriaRepository, 
                                    IMapper mapper,
                                    ICategoriaService categoriaService) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriaViewModel>> ObterPorId(int id)
        {
            var categoria = await ObterCategoriaId(id);

            if (categoria == null) return NotFound();

            return categoria;
        }
        [HttpPost]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoriaService.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));

            return CustomResponse(categoriaViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoriaViewModel>> Atualizar(int id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(categoriaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoriaService.Atualizar(_mapper.Map<Categoria>(categoriaViewModel));

            return CustomResponse(categoriaViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaViewModel>> Excluir(int id)
        {
            var categoria = await ObterCategoriaId(id);

            if (categoria == null) return NotFound();

            await _categoriaService.Remover(id);

            return CustomResponse(categoria);
        }

        private async Task<CategoriaViewModel> ObterCategoriaId(int id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorId(id));
        }
    }
}
