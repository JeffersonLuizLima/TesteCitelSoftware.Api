using DevCitel.Business.Intefaces;
using DevCitel.Business.Models;
using DevCitel.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCitel.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context) { }

        public async Task<Produto> ObterProdutoCategoria(int id)
        {
            return await Db.Produtos.AsNoTracking().Include(c => c.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosCategirias()
        {
            return await Db.Produtos.AsNoTracking().Include(c => c.Categoria)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorCategoria(int categoriaId)
        {
            return await Buscar(p => p.Categoria.Id == categoriaId);
        }
    }
}
