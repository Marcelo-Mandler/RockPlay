using System.Collections.Generic;

namespace RockPlay.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T objeto);
        void Atualiza(int id, T objeto);
        void Exclui(int id);
        int ProximoId();

    }
}