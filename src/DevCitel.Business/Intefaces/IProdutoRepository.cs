using DevCitel.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevCitel.Business.Intefaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorCategoria(int categoriaId);
        Task<IEnumerable<Produto>> ObterProdutosCategirias();
        Task<Produto> ObterProdutoCategoria(int id);
    }
}
