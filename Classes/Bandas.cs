using System;

namespace RockPlay
{
    public class Bandas : IdentificacaoBase
    {
        //Atributos da classe
        private Genero Genero { get; set; }
        private string Banda { get; set; }
        private string Album { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        //Método

       public Bandas(int id, Genero genero, string banda, string album, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Banda = banda;
            this.Album = album;
            this.Ano = ano;
            this.Excluido = false;

        }

        public override string ToString()
        {
            string retorno = " ";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Banda: " + this.Banda + Environment.NewLine;
            retorno += "Álbum: " + this.Album + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido + Environment.NewLine;
            return retorno;
            
        }

        public string retornaBanda()
        {
            return this.Banda;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }


    }
}