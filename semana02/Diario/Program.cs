/*
 * Adicionei o campo "Humor/Sentimento" para enriquecer cada registro do diário.
 * Implementei suporte ao formato CSV com tratamento para aspas duplas, vírgulas e quebras de linha nas respostas.
 * Garanti que o arquivo receba a extensão .csv automaticamente, mesmo se o usuário não digitar ".csv" na extensão do arquivo.
 * Usei codificação UTF-8 para preservar corretamente as acentuações da língua portuguesa ao salvar e carregar.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        Diario meuDiario = new Diario();
        GeradorDePerguntas gerador = new GeradorDePerguntas();
        bool executando = true;

        while (executando)
        {
            Console.WriteLine("Bem-vindo ao Diário Pessoal!");
            Console.WriteLine("Escolha uma das opções abaixo:");
            Console.WriteLine("1. Escrever novo registro");
            Console.WriteLine("2. Exibir diário");
            Console.WriteLine("3. Carregar diário de um arquivo");
            Console.WriteLine("4. Salvar diário em um arquivo");
            Console.WriteLine("5. Sair");
            Console.Write("O que deseja fazer? ");

            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    string pergunta = gerador.ObterPerguntaAleatoria();
                    Console.WriteLine(pergunta);
                    Console.Write("> ");
                    string resposta = Console.ReadLine();

                    Console.Write("Como você está se sentindo agora (humor/estado de espírito)? ");
                    string humor = Console.ReadLine();

                    meuDiario.AdicionarRegistro(new Registro(pergunta, resposta, humor));
                    Console.WriteLine();
                    break;

                case "2":
                    meuDiario.ExibirTodos();
                    break;

                case "3":
                    Console.Write("Digite o nome do arquivo para carregar (ex: diario.csv): ");
                    string nomeArquivoCarregar = Console.ReadLine();
                    if (!nomeArquivoCarregar.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    {
                        nomeArquivoCarregar += ".csv";
                    }
                    meuDiario.CarregarDoArquivo(nomeArquivoCarregar);
                    break;

                case "4":
                    Console.Write("Digite o nome do arquivo para salvar (ex: diario.csv): ");
                    string nomeArquivoSalvar = Console.ReadLine();
                    if (!nomeArquivoSalvar.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    {
                        nomeArquivoSalvar += ".csv";
                    }
                    meuDiario.SalvarNoArquivo(nomeArquivoSalvar);
                    break;

                case "5":
                    executando = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.\n");
                    break;
            }
        }
    }
}