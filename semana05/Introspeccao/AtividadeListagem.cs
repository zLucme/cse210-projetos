using System;
using System.Collections.Generic;

namespace ProgramaIntrospeccao
{
    public class AtividadeListagem : Atividade
    {
        private List<string> _mensagens;
        private Queue<string> _mensagensNaoUsadas;
        private Random _aleatorio;

        public AtividadeListagem() : base(
            "Atividade de Listagem",
            "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, " +
            "fazendo com que você liste o máximo de coisas que puder em uma determinada área.")
        {
            _aleatorio = new Random();
            _mensagens = new List<string>
            {
                "Quem são as pessoas que você aprecia?",
                "Quais são seus pontos fortes pessoais?",
                "Quem são as pessoas que você ajudou esta semana?",
                "Quando você sentiu o Espírito Santo neste mês?",
                "Quem são alguns dos seus heróis pessoais?"
            };
            _mensagensNaoUsadas = new Queue<string>();
        }

        public override void Executar()
        {
            ExibirMensagemInicial();

            Console.WriteLine("Liste o máximo de respostas que puder para a seguinte pergunta:");
            Console.WriteLine($" --- {ObterMensagemAleatoria()} --- ");
            Console.Write("Você pode começar em: ");
            ExibirContagemRegressiva(5);
            Console.WriteLine();

            List<string> itens = ObterListaDoUsuario();

            Console.WriteLine($"\nVocê listou {itens.Count} itens!");

            ExibirMensagemFinal();
        }

        private string ObterMensagemAleatoria()
        {
            if (_mensagensNaoUsadas.Count == 0)
            {
                List<string> temporaria = new List<string>(_mensagens);
                for (int i = temporaria.Count - 1; i > 0; i--)
                {
                    int j = _aleatorio.Next(i + 1);
                    string troca = temporaria[i];
                    temporaria[i] = temporaria[j];
                    temporaria[j] = troca;
                }
                foreach (string item in temporaria)
                {
                    _mensagensNaoUsadas.Enqueue(item);
                }
            }
            return _mensagensNaoUsadas.Dequeue();
        }

        private List<string> ObterListaDoUsuario()
        {
            List<string> itensUsuario = new List<string>();
            DateTime horaInicio = DateTime.Now;
            DateTime horaFim = horaInicio.AddSeconds(Duracao);

            while (DateTime.Now < horaFim)
            {
                Console.Write("> ");
                string resposta = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(resposta))
                {
                    itensUsuario.Add(resposta.Trim());
                }
            }

            return itensUsuario;
        }
    }
}
