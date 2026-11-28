using System;
using System.Collections.Generic;
using System.IO;

namespace ProgramaIntrospeccao
{
    public class RegistroAtividades
    {
        private string _caminhoArquivoLog = "registro_introspeccao.txt";
        private Dictionary<string, int> _contagemAtividades;
        private Dictionary<string, int> _segundosAtividades;

        public RegistroAtividades()
        {
            _contagemAtividades = new Dictionary<string, int>();
            _segundosAtividades = new Dictionary<string, int>();
            CarregarRegistro();
        }

        public void RegistrarAtividade(string nomeAtividade, int duracaoSegundos)
        {
            if (!_contagemAtividades.ContainsKey(nomeAtividade))
            {
                _contagemAtividades[nomeAtividade] = 0;
                _segundosAtividades[nomeAtividade] = 0;
            }

            _contagemAtividades[nomeAtividade]++;
            _segundosAtividades[nomeAtividade] += duracaoSegundos;
            SalvarRegistro();
        }

        public void ExibirEstatisticas()
        {
            Console.Clear();
            Console.WriteLine("=== Histórico e Estatísticas de Introspecção ===");
            Console.WriteLine();

            if (_contagemAtividades.Count == 0)
            {
                Console.WriteLine("Nenhuma atividade foi concluída ainda.");
            }
            else
            {
                int totalSessoes = 0;
                int tempoTotal = 0;

                foreach (var entrada in _contagemAtividades)
                {
                    string nome = entrada.Key;
                    int contagem = entrada.Value;
                    int segundos = _segundosAtividades[nome];

                    totalSessoes += contagem;
                    tempoTotal += segundos;

                    Console.WriteLine($"- {nome}: {contagem} vez(es) | Tempo total: {segundos} segundos");
                }

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Total Geral: {totalSessoes} sessões concluídas ({tempoTotal} segundos).");
            }

            Console.WriteLine("\nPressione Enter para voltar ao menu...");
            Console.ReadLine();
        }

        private void SalvarRegistro()
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(_caminhoArquivoLog))
                {
                    foreach (var entrada in _contagemAtividades)
                    {
                        string nome = entrada.Key;
                        int contagem = entrada.Value;
                        int segundos = _segundosAtividades[nome];
                        escritor.WriteLine($"{nome}|{contagem}|{segundos}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Aviso] Não foi possível salvar o arquivo de registro: {ex.Message}");
            }
        }

        private void CarregarRegistro()
        {
            try
            {
                if (!File.Exists(_caminhoArquivoLog))
                {
                    return;
                }

                string[] linhas = File.ReadAllLines(_caminhoArquivoLog);
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split('|');
                    if (partes.Length == 3 &&
                        int.TryParse(partes[1], out int contagem) &&
                        int.TryParse(partes[2], out int segundos))
                    {
                        _contagemAtividades[partes[0]] = contagem;
                        _segundosAtividades[partes[0]] = segundos;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Aviso] Não foi possível carregar o histórico anterior: {ex.Message}");
            }
        }
    }
}
