using DevCitel.Business.Intefaces;
using DevCitel.Business.Models;
using DevCitel.Business.Models.Validations;
using System.Linq;
using System.Threading.Tasks;

namespace DevCitel.Business.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository,
                                IProdutoRepository produtoRepository,
                                INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return;

            if (_categoriaRepository.Buscar(c => c.Descricao == categoria.Descricao).Result.Any())
            {
                Notificar("Já existe uma categoria com este nome informado.");
                return;
            }

            await _categoriaRepository.Adicionar(categoria);
        }

        public async Task Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return;

            if (_categoriaRepository.Buscar(c => c.Descricao == categoria.Descricao && c.Id != categoria.Id).Result.Any())
            {
                Notificar("Já existe uma categoria com este nome informado.");
                return;
            }

            await _categoriaRepository.Atualizar(categoria);
        }

        public async Task Remover(int id)
        {
            if (_produtoRepository.ObterProdutosPorCategoria(id).Result.Any())
            {
                 Notificar("A Categoria possui produtos cadastrados!");
                return;
            }

            await _categoriaRepository.Remover(id);
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}
