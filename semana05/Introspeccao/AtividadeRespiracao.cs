using System;
using System.Threading;

namespace ProgramaIntrospeccao
{
    public class AtividadeRespiracao : Atividade
    {
        public AtividadeRespiracao() : base(
            "Atividade de Respiração",
            "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. " +
            "Limpe sua mente e concentre-se na sua respiração.")
        {
        }

        public override void Executar()
        {
            ExibirMensagemInicial();

            DateTime horaInicio = DateTime.Now;
            DateTime horaFim = horaInicio.AddSeconds(Duracao);

            while (DateTime.Now < horaFim)
            {
                Console.Write("\nInspire... ");
                ExibirAnimacaoRespiracaoDinamica(4, true);

                if (DateTime.Now >= horaFim)
                {
                    break;
                }

                Console.Write("\nExpire...  ");
                ExibirAnimacaoRespiracaoDinamica(6, false);
                Console.WriteLine();
            }

            ExibirMensagemFinal();
        }

        private void ExibirAnimacaoRespiracaoDinamica(int segundos, bool inspirando)
        {
            int totalMilissegundos = segundos * 1000;
            int somaPesos = (segundos * (segundos + 1)) / 2;

            for (int passo = 1; passo <= segundos; passo++)
            {
                int restante = segundos - passo + 1;
                int tamanhoBarra = inspirando ? passo * 2 : restante * 2;
                string barra = new string('█', tamanhoBarra).PadRight(segundos * 2, '░');

                string exibicao = $"{restante} [{barra}]";
                Console.Write(exibicao);

                int atrasoMs = (totalMilissegundos * passo) / somaPesos;
                Thread.Sleep(atrasoMs);

                Console.Write(new string('\b', exibicao.Length) + new string(' ', exibicao.Length) + new string('\b', exibicao.Length));
            }
        }
    }
}
