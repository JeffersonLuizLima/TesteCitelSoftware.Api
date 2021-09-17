using DevCitel.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevCitel.Business.Intefaces
{
    public interface ICategoriaService : IDisposable
    {
        Task Adicionar(Categoria categoria);
        Task Atualizar(Categoria categoria);
        Task Remover(int id);
    }
}
