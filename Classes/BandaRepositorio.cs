using System.Collections.Generic;
using RockPlay.Interfaces;

namespace RockPlay
{
    public class BandaRepositorio : IRepositorio<Bandas>
    {
        private List<Bandas> listaBanda = new List<Bandas>();
        public void Atualiza(int id, Bandas objeto)
        {
            listaBanda[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaBanda[id].Excluir();
        }

        public void Insere(Bandas objeto)
        {
            listaBanda.Add(objeto);
        }

        public List<Bandas> Lista()
        {
            return listaBanda;
        }

        public int ProximoId()
        {
            return listaBanda.Count;
        }

        public Bandas RetornaPorId(int id)
        {
            return listaBanda[id];
        }
    }
}