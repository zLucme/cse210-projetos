using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Diario
{
    public List<Registro> _registros = new List<Registro>();

    public void AdicionarRegistro(Registro novoRegistro)
    {
        _registros.Add(novoRegistro);
    }

    public void ExibirTodos()
    {
        if (_registros.Count == 0)
        {
            Console.WriteLine("O diário está vazio.\n");
            return;
        }

        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }
    }

    public void SalvarNoArquivo(string arquivo)
    {
        using (StreamWriter escritor = new StreamWriter(arquivo, false, Encoding.UTF8))
        {
            foreach (Registro registro in _registros)
            {
                escritor.WriteLine(registro.ParaFormatoCsv());
            }
        }
        Console.WriteLine("Diário salvo com sucesso!\n");
    }

    public void CarregarDoArquivo(string arquivo)
    {
        if (!File.Exists(arquivo))
        {
            Console.WriteLine("Arquivo não encontrado.\n");
            return;
        }

        _registros.Clear();
        string[] linhas = File.ReadAllLines(arquivo, Encoding.UTF8);

        foreach (string linha in linhas)
        {
            if (string.IsNullOrWhiteSpace(linha))
            {
                continue;
            }

            List<string> colunas = AnalisarLinhaCsv(linha);
            if (colunas.Count >= 4)
            {
                _registros.Add(new Registro(colunas[0], colunas[2], colunas[3], colunas[1]));
            }
            else if (colunas.Count == 3)
            {
                _registros.Add(new Registro(colunas[0], colunas[1], colunas[2], "Não informado"));
            }
        }
        Console.WriteLine("Diário carregado com sucesso!\n");
    }

    private List<string> AnalisarLinhaCsv(string linha)
    {
        List<string> resultado = new List<string>();
        StringBuilder valorAtual = new StringBuilder();
        bool dentroDeAspas = false;

        for (int i = 0; i < linha.Length; i++)
        {
            char caractereAtual = linha[i];

            if (caractereAtual == '\"')
            {
                if (dentroDeAspas && i + 1 < linha.Length && linha[i + 1] == '\"')
                {
                    valorAtual.Append('\"');
                    i++;
                }
                else
                {
                    dentroDeAspas = !dentroDeAspas;
                }
            }
            else if (caractereAtual == ',' && !dentroDeAspas)
            {
                resultado.Add(valorAtual.ToString());
                valorAtual.Clear();
            }
            else
            {
                valorAtual.Append(caractereAtual);
            }
        }

        resultado.Add(valorAtual.ToString());
        return resultado;
    }
}