using System;

public class Comentario
{
    private string _nomeAutor;
    private string _texto;

    public Comentario(string nomeAutor, string texto)
    {
        _nomeAutor = nomeAutor;
        _texto = texto;
    }

    public string ObterComentarioFormatado()
    {
        return $"{_nomeAutor}: {_texto}";
    }

    public void ExibirComentario()
    {
        Console.WriteLine($"  - {ObterComentarioFormatado()}");
    }
}