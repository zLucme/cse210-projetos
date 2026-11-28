using System;
using System.Collections.Generic;

namespace ProgramaIntrospeccao
{
    public class AtividadeReflexao : Atividade
    {
        private List<string> _mensagens;
        private List<string> _perguntas;
        private Queue<string> _mensagensNaoUsadas;
        private Queue<string> _perguntasNaoUsadas;
        private Random _aleatorio;

        public AtividadeReflexao() : base(
            "Atividade de Reflexão",
            "Esta atividade ajudará você a refletir sobre momentos da sua vida em que você " +
            "demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que você tem " +
            "e como pode usá-lo em outros aspectos da sua vida.")
        {
            _aleatorio = new Random();

            _mensagens = new List<string>
            {
                "Pense em uma ocasião em que você defendeu outra pessoa.",
                "Pense em uma ocasião em que você fez algo realmente difícil.",
                "Pense em uma ocasião em que você ajudou alguém necessitado.",
                "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
            };

            _perguntas = new List<string>
            {
                "Por que essa experiência foi significativa para você?",
                "Você já fez algo assim antes?",
                "Como você começou?",
                "Como você se sentiu quando terminou?",
                "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
                "Qual é a sua coisa favorita sobre essa experiência?",
                "O que você pode aprender com essa experiência que se aplica a outras situações?",
                "O que você aprendeu sobre si mesmo por meio dessa experiência?",
                "Como você pode manter essa experiência em mente no futuro?"
            };

            _mensagensNaoUsadas = new Queue<string>();
            _perguntasNaoUsadas = new Queue<string>();
        }

        public override void Executar()
        {
            ExibirMensagemInicial();

            Console.WriteLine("Considere a seguinte situação:");
            Console.WriteLine();
            Console.WriteLine($" --- {ObterMensagemAleatoria()} --- ");
            Console.WriteLine();
            Console.WriteLine("Quando tiver algo em mente, pressione Enter para continuar.");
            Console.ReadLine();

            Console.WriteLine("Agora pondere sobre cada uma das seguintes perguntas conforme elas se relacionam com essa experiência.");
            Console.Write("Você pode começar em: ");
            ExibirContagemRegressiva(5);

            Console.Clear();

            DateTime horaInicio = DateTime.Now;
            DateTime horaFim = horaInicio.AddSeconds(Duracao);

            while (DateTime.Now < horaFim)
            {
                string pergunta = ObterPerguntaAleatoria();
                Console.Write($"> {pergunta} ");
                ExibirIndicadorProgresso(8);
                Console.WriteLine();
            }

            ExibirMensagemFinal();
        }

        private string ObterMensagemAleatoria()
        {
            if (_mensagensNaoUsadas.Count == 0)
            {
                ReabastecerFila(_mensagens, _mensagensNaoUsadas);
            }
            return _mensagensNaoUsadas.Dequeue();
        }

        private string ObterPerguntaAleatoria()
        {
            if (_perguntasNaoUsadas.Count == 0)
            {
                ReabastecerFila(_perguntas, _perguntasNaoUsadas);
            }
            return _perguntasNaoUsadas.Dequeue();
        }

        private void ReabastecerFila(List<string> origem, Queue<string> filaDestino)
        {
            List<string> temporaria = new List<string>(origem);
            for (int i = temporaria.Count - 1; i > 0; i--)
            {
                int j = _aleatorio.Next(i + 1);
                string troca = temporaria[i];
                temporaria[i] = temporaria[j];
                temporaria[j] = troca;
            }

            foreach (string item in temporaria)
            {
                filaDestino.Enqueue(item);
            }
        }
    }
}
