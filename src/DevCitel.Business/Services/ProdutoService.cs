using DevCitel.Business.Intefaces;
using DevCitel.Business.Models;
using DevCitel.Business.Models.Validations;
using System.Linq;
using System.Threading.Tasks;

namespace DevCitel.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            if (_produtoRepository.Buscar(p => p.Nome == produto.Nome).Result.Any())
            {
                Notificar("Já existe um produto com este nome informado.");
                return;
            }

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            if (_produtoRepository.Buscar(p => p.Nome == produto.Nome && p.Id != produto.Id).Result.Any())
            {
                Notificar("Já existe um produto com este nome informado.");
                return;
            }

            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(int id)
        {
            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
