using System;
using System.Collections.Generic;
using System.Threading;

namespace ProgramaIntrospeccao
{
    public abstract class Atividade
    {
        private string _nome;
        private string _descricao;
        private int _duracao;

        protected Atividade(string nome, string descricao)
        {
            _nome = nome;
            _descricao = descricao;
            _duracao = 0;
        }

        public string Nome => _nome;
        public int Duracao => _duracao;

        public void ExibirMensagemInicial()
        {
            Console.Clear();
            Console.WriteLine($"Bem-vindo à {_nome}.");
            Console.WriteLine();
            Console.WriteLine(_descricao);
            Console.WriteLine();

            while (true)
            {
                Console.Write("Quanto tempo, em segundos, você gostaria que durasse esta sessão? ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int segundos) && segundos > 0)
                {
                    _duracao = segundos;
                    break;
                }
                Console.WriteLine("Por favor, insira um número inteiro válido maior que zero.");
            }

            Console.Clear();
            Console.WriteLine("Prepare-se...");
            ExibirIndicadorProgresso(4);
            Console.WriteLine();
        }

        public void ExibirMensagemFinal()
        {
            Console.WriteLine();
            Console.WriteLine("Muito bem! Você fez um ótimo trabalho.");
            ExibirIndicadorProgresso(4);
            Console.WriteLine();
            Console.WriteLine($"Você concluiu mais {_duracao} segundos da {_nome}.");
            ExibirIndicadorProgresso(5);
        }

        public void ExibirIndicadorProgresso(int segundos)
        {
            List<string> simbolosAnimacao = new List<string> { "|", "/", "-", "\\" };
            DateTime horaInicio = DateTime.Now;
            DateTime horaFim = horaInicio.AddSeconds(segundos);

            int indice = 0;
            while (DateTime.Now < horaFim)
            {
                string simbolo = simbolosAnimacao[indice];
                Console.Write(simbolo);
                Thread.Sleep(250);
                Console.Write("\b \b");

                indice++;
                if (indice >= simbolosAnimacao.Count)
                {
                    indice = 0;
                }
            }
        }

        public void ExibirContagemRegressiva(int segundos)
        {
            for (int i = segundos; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);

                string digitos = i.ToString();
                for (int d = 0; d < digitos.Length; d++)
                {
                    Console.Write("\b \b");
                }
            }
        }

        public abstract void Executar();
    }
}
