using System;

namespace RockPlay
{
    class Program
    {
        static BandaRepositorio repositorio = new BandaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() !="X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarBandas();
                        break;
                    case "2":
                        InserirBanda();
                        break;
                    case "3":
                        AtualizarBanda();
                        break;
                    case "4":
                        ExcluirBanda();
                        break;
                    case "5":
                        VisualizarBanda();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigador por");

        }

        private static void ListarBandas()
        {
            Console.WriteLine(" Listar Bandas:");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma banda cadastrada.");
                return;
            }
            foreach (var banda in lista)
            {
                var excluido = banda.retornaExcluido();
                Console.WriteLine("#ID {0} - {1} {2}", banda.retornaId(), banda.retornaBanda(), (excluido? "*Excluído*" : ""));
            }
        }

        private static void InserirBanda()
        {
            Console.WriteLine("Inserir Banda");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Gênero Entre as Opções Acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome da Banda: ");
            string entradaBanda = Console.ReadLine();

            Console.Write("Digite o Álbum: ");
            string entradaAlbum = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento do Álbum: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Bandas novaBanda = new Bandas(id: repositorio.ProximoId(), 
            genero: (Genero)entradaGenero, 
            banda: entradaBanda, 
            album: entradaAlbum,
            ano: entradaAno);

            repositorio.Insere(novaBanda);
        }

        private static void AtualizarBanda()
        {
            Console.Write("Digite o ID da Banda: ");
            int indiceBanda = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Gênero Entre as Opções Acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Nova Banda: ");
            string entradaBanda = Console.ReadLine();
            
            Console.Write("Digite o Álbum: ");
            string entradaAlbum = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Bandas atualizaBanda = new Bandas(id: indiceBanda,
            genero: (Genero)entradaGenero,
            banda: entradaBanda,
            album: entradaAlbum,
            ano: entradaAno);

            repositorio.Atualiza(indiceBanda, atualizaBanda);
        }

        private static void ExcluirBanda()//Tentar melhorar perguntando se realmente quer excluir
        {
            Console.Write("Digite o Id da Banda: ");
            int indiceBanda = int.Parse(Console.ReadLine());
            Console.WriteLine("Deseja Realmente Excluir a Banda? (S/N)");
            string resposta = Console.ReadLine();
            if(resposta.ToUpper() == "S")
            {
                repositorio.Exclui(indiceBanda);
            }
            else if(resposta.ToUpper() == "N")
            {
                return;
            }
        }

        private static void VisualizarBanda()
        {
            Console.Write("Digite o Id da Banda: ");
            int indiceBanda = int.Parse(Console.ReadLine());

            var banda = repositorio.RetornaPorId(indiceBanda);
            Console.WriteLine(banda);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Rock Band ao seu dispor.");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Bandas");
            Console.WriteLine("2 -Inserir Nova Banda ");
            Console.WriteLine("3 - Atualizar Banda");
            Console.WriteLine("4 - Excluir Banda");
            Console.WriteLine("5 - Visualizar Banda");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            

        }

    }
}
