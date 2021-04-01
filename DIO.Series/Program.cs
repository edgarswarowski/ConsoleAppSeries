using System;

namespace DIO.Series
{
    class Program
    {
		static SerieRepositorio repositorio = new SerieRepositorio();
		static void Main(string[] args)
        {
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

        private static void VisualizarSerie() //METODO PARA RETORNAR A SERIE CONFORME ID ESPECIFICO
        {
			Console.WriteLine("### - Visualizar Séries - ###");

			Console.WriteLine("Digite o Id da serie a ser visualizada:");
			int visuId = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(visuId);

			Console.WriteLine(serie);
		}

        private static void ExcluirSerie() //METODO PARA TORNAR A TRUE A CONDICAO DE EXCLUIDA DA SERIE
        {
			Console.WriteLine("### - Excluir Séries - ###");

			Console.WriteLine("Digite o Id a ser excluído:");
			int excluirId = int.Parse(Console.ReadLine());

			repositorio.Exclui(excluirId);

		}

        private static void AtualizarSerie() //METODO PARA ATUALIZAR AS SERIES DO REPOSITORIO
        {
			Console.WriteLine("### - Atualizar Séries - ###");

			Console.WriteLine("Digite o ID a atualizar:");
			int atualizaId = int.Parse(Console.ReadLine());
						
			foreach (int i in Enum.GetValues(typeof(Genero))) //LISTAR OS GENEROS CADASTRADOS NA CLASE GENERO
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int atualizaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o titulo da série:");
			string atualizaTitulo = Console.ReadLine();

			Console.WriteLine("Digite a descrição da série:");
			string atualizaDescricao = Console.ReadLine();

			Console.WriteLine("Digite o ano da série:");
			int atualizadaAno = int.Parse(Console.ReadLine());

			//CRIAR NOVA SERIE
			Serie atualizaSerie = new Serie(
				id: atualizaId,
				genero: (Genero)atualizaGenero,
				titulo: atualizaTitulo,
				descricao: atualizaDescricao,
				ano: atualizadaAno);

			repositorio.Atualiza(atualizaId, atualizaSerie);
		}

		private static void InserirSerie() //METODO PARA CRIAR NOVA SERIE NO REPOSITORIO
        {
			Console.WriteLine("### - Inserir Séries - ###");

			foreach (int i in Enum.GetValues(typeof(Genero))) //LISTAR OS GENEROS CADASTRADOS NA CLASE GENERO
            {
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o titulo da série:");
			string entradaTitulo = Console.ReadLine();

			Console.WriteLine("Digite a descrição da série:");
			string entradaDescricao = Console.ReadLine();

			Console.WriteLine("Digite o ano da série:");
			int entradaAno = int.Parse(Console.ReadLine());

			//CRIAR NOVA SERIE
			Serie serie = new Serie(
				id: repositorio.ProximoId(),
				genero: (Genero)entradaGenero,
				titulo: entradaTitulo,
				descricao: entradaDescricao,
				ano: entradaAno);

			repositorio.Insere(serie);

			Console.WriteLine("Serie inserida com sucesso!");
	}

        private static void ListarSeries() //METODO PARA LISTAR AS SERIES CADASTRADAS NO REPOSITORIO
        {
			Console.WriteLine("### - Listar Séries - ###");

			var serieListar = repositorio.Lista();

			if (serieListar.Count == 0)
            {
				Console.WriteLine("Nenhuma série cadastrada!!!");
				return;
            }
			
			foreach(var serie in serieListar)
            {
				var excluido = serie.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
