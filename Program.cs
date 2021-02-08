using System;

namespace projeto02
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
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
                        Console.WriteLine("Insira dados válidos\nAperte Enter para prosseguir");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
            Console.ReadLine();
            Console.Clear();
        }

        private static void VisualizarSerie()
        {
            try{
                Console.WriteLine("Visualizar série");

                Console.WriteLine("Digite o Id da série: ");
                int entradaId = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornaPorId(entradaId);

                Console.WriteLine(serie);
            } catch {
                Console.WriteLine("Insira dados válidos\nAperte Enter para proseguir");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }

        private static void ExcluirSerie()
        {
            try{
                Console.WriteLine("Excluir série");

                Console.WriteLine("Digite o Id da série: ");
                int entradaId = int.Parse(Console.ReadLine());

                repositorio.Exclui(entradaId);
            } catch {
                Console.WriteLine("Insira dados válidos\nAperte Enter para proseguir");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }

        private static void AtualizarSerie()
        {
            try{
                Console.WriteLine("Atualizar série");

                Console.WriteLine("Digite o Id da série: ");
                int entradaId = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornaPorId(entradaId); //verifica se a série existe no repositório

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
                }

                Console.WriteLine("Digite o genêro entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.WriteLine("Digite o Ano de início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie(
                    entradaId, 
                    (Genero)entradaGenero, 
                    entradaTitulo, 
                    entradaDescricao,
                    entradaAno);
                repositorio.Atualiza(entradaId, novaSerie);
            } catch {
                Console.WriteLine("Insira dados válidos\nAperte Enter para proseguir");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }

        private static void InserirSerie()
        {
            try {
                Console.WriteLine("Inserir nova série");

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
                }

                Console.WriteLine("Digite o genêro entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.WriteLine("Digite o Ano de início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie(
                    id: repositorio.ProximoId(), 
                    genero: (Genero)entradaGenero, 
                    titulo: entradaTitulo, 
                    descricao: entradaDescricao,
                    ano: entradaAno);
                repositorio.Insere(novaSerie);
            } catch {
                Console.WriteLine("Insira dados válidos\nAperte Enter para proseguir");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var series = repositorio.Lista();

            if(series.Count == 0){
                Console.WriteLine("Não existem séries no repositório");
                return;
            } else {
                foreach(var serie in series){
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()} - {(excluido ? "*Excluído*" : "")}");
                }
            }
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Localiza Series a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova séries");
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
