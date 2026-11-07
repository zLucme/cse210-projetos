using System;

public class Registro
{
    public string _data;
    public string _textoPergunta;
    public string _textoResposta;
    public string _humor;

    public Registro(string textoPergunta, string textoResposta, string humor)
    {
        _data = DateTime.Now.ToShortDateString();
        _textoPergunta = textoPergunta;
        _textoResposta = textoResposta;
        _humor = humor;
    }

    public Registro(string data, string textoPergunta, string textoResposta, string humor)
    {
        _data = data;
        _textoPergunta = textoPergunta;
        _textoResposta = textoResposta;
        _humor = humor;
    }

    public void Exibir()
    {
        Console.WriteLine($"Data: {_data} - Humor: {_humor} - Pergunta: {_textoPergunta}");
        Console.WriteLine($"{_textoResposta}\n");
    }

    public string ParaFormatoCsv()
    {
        return $"{EscaparCsv(_data)},{EscaparCsv(_humor)},{EscaparCsv(_textoPergunta)},{EscaparCsv(_textoResposta)}";
    }

    private static string EscaparCsv(string campo)
    {
        if (campo.Contains(',') || campo.Contains('"') || campo.Contains('\n') || campo.Contains('\r'))
        {
            return $"\"{campo.Replace("\"", "\"\"")}\"";
        }
        return campo;
    }
}