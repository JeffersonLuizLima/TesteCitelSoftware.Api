using DevCitel.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevCitel.Business.Intefaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(int id);
    }
}
