using System.Collections.Generic;

namespace Aula31Whatzap
{
    public interface IAgenda
    {
         void Cadastrar(Contato cont);
         void Excluir(string _termo);
         List<Contato> Listar();
    }
}