using System;
using System.Collections.Generic;

namespace ProgramaIntrospeccao
{
    public class AtividadeGratidao : Atividade
    {
        private List<string> _temas;
        private Random _aleatorio;

        public AtividadeGratidao() : base(
            "Atividade de Gratidão",
            "Esta atividade ajudará você a cultivar um coração grato, escrevendo breves notas " +
            "de agradecimento ou reconhecimento sobre aspectos específicos do seu dia a dia.")
        {
            _aleatorio = new Random();
            _temas = new List<string>
            {
                "Uma pequena bênção ou conforto que você costuma dar como garantido.",
                "Um desafio superado recentemente que trouxe aprendizado.",
                "Uma habilidade ou talento que permite que você ajude outras pessoas.",
                "Uma lembrança feliz da sua família ou de amigos queridos."
            };
        }

        public override void Executar()
        {
            ExibirMensagemInicial();

            string tema = _temas[_aleatorio.Next(_temas.Count)];
            Console.WriteLine("Escreva livremente frases de gratidão sobre o seguinte tema:");
            Console.WriteLine($" --- {tema} --- ");
            Console.Write("Prepare seus pensamentos: ");
            ExibirContagemRegressiva(5);
            Console.WriteLine("\n");

            DateTime horaInicio = DateTime.Now;
            DateTime horaFim = horaInicio.AddSeconds(Duracao);
            int quantidadeFrases = 0;

            while (DateTime.Now < horaFim)
            {
                Console.Write("Sou grato por: ");
                string anotacao = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(anotacao))
                {
                    quantidadeFrases++;
                }
            }

            Console.WriteLine($"\nVocê registrou {quantidadeFrases} expressões de gratidão!");
            ExibirMensagemFinal();
        }
    }
}
