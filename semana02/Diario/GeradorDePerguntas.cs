using System;
using System.Collections.Generic;

public class GeradorDePerguntas
{
    public List<string> _perguntas = new List<string>
    {
        "Quem foi a pessoa mais interessante com quem conversei hoje?",
        "Qual foi a melhor parte do meu dia?",
        "Como vi a mão de Deus na minha vida hoje?",
        "Qual foi a emoção mais marcante que senti hoje?",
        "Se eu pudesse refazer uma coisa hoje, o que seria?",
        "Qual foi o maior aprendizado que tive no dia de hoje?",
        "Pelo que sou mais grato no dia de hoje?",
        "Qual foi o maior desafio que enfrentei hoje e como lidei com ele?",
        "De que maneira pude ajudar ou servir alguém hoje?",
        "O que fiz hoje que me deixou orgulhoso?"
    };

    private Random _aleatorio = new Random();

    public string ObterPerguntaAleatoria()
    {
        int indiceAleatorio = _aleatorio.Next(_perguntas.Count);
        return _perguntas[indiceAleatorio];
    }
}