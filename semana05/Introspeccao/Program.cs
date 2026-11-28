/*
* Nova atividade adicionada: AtividadeGratidao (Atividade de Gratidão). Garantia de que nenhuma pergunta ou mensagem aleatória seja
* repetida até que todas tenham sido exibidas (usando filas embaralhadas nas atividades de Reflexão e Listagem). Registro de
* estatísticas (quantidade de vezes e tempo total de cada atividade) salvo e carregado automaticamente em arquivo de texto
* (registro_introspeccao.txt). Animação dinâmica de respiração que acelera no início e desacelera gradualmente no final, acompanhada
* de barra visual expansiva.
*/

using System;

namespace ProgramaIntrospeccao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AtividadeRespiracao respiracao = new AtividadeRespiracao();
            AtividadeReflexao reflexao = new AtividadeReflexao();
            AtividadeListagem listagem = new AtividadeListagem();
            AtividadeGratidao gratidao = new AtividadeGratidao();
            RegistroAtividades registro = new RegistroAtividades();

            bool executando = true;
            while (executando)
            {
                Console.Clear();
                Console.WriteLine("Opções do Menu:");
                Console.WriteLine("  1. Iniciar atividade de respiração");
                Console.WriteLine("  2. Iniciar atividade de reflexão");
                Console.WriteLine("  3. Iniciar atividade de listagem");
                Console.WriteLine("  4. Iniciar atividade de gratidão");
                Console.WriteLine("  5. Ver estatísticas e histórico");
                Console.WriteLine("  6. Sair");
                Console.Write("Selecione uma opção do menu: ");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        respiracao.Executar();
                        registro.RegistrarAtividade(respiracao.Nome, respiracao.Duracao);
                        break;

                    case "2":
                        reflexao.Executar();
                        registro.RegistrarAtividade(reflexao.Nome, reflexao.Duracao);
                        break;

                    case "3":
                        listagem.Executar();
                        registro.RegistrarAtividade(listagem.Nome, listagem.Duracao);
                        break;

                    case "4":
                        gratidao.Executar();
                        registro.RegistrarAtividade(gratidao.Nome, gratidao.Duracao);
                        break;

                    case "5":
                        registro.ExibirEstatisticas();
                        break;

                    case "6":
                        executando = false;
                        Console.WriteLine("\nObrigado por reservar um tempo para cuidar da sua mente. Até logo!");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida. Pressione Enter para tentar novamente...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
