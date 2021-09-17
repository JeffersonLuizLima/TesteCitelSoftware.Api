using DevCitel.Business.Intefaces;
using DevCitel.Business.Models;
using DevCitel.Data.Context;

namespace DevCitel.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(MeuDbContext context) : base(context) { }
    }
}
