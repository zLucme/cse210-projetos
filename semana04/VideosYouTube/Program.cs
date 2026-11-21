using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Análise de Produto em Teste Prático", "Tech Brasil", 420);
        video1.AdicionarComentario(new Comentario("Lucas Almeida", "Ótimo teste, mostrou bem o uso no dia a dia."));
        video1.AdicionarComentario(new Comentario("Mariana Costa", "Estava procurando exatamente esse tipo de review."));
        video1.AdicionarComentario(new Comentario("Rafael Souza", "Bem direto ao ponto e sem enrolação."));
        videos.Add(video1);

        Video video2 = new Video("Como Escolher Equipamento para o Trabalho", "Produtividade em Foco", 615);
        video2.AdicionarComentario(new Comentario("Camila Rocha", "Ajudou muito a comparar os modelos."));
        video2.AdicionarComentario(new Comentario("Bruno Pereira", "Explicação bem clara sobre custo-benefício."));
        video2.AdicionarComentario(new Comentario("Fernanda Lima", "Vou salvar para rever antes de comprar."));
        video2.AdicionarComentario(new Comentario("Diego Martins", "Excelente comparação prática."));
        videos.Add(video2);

        Video video3 = new Video("Bastidores de Produção e Rotina Operacional", "Indústria Hoje", 530);
        video3.AdicionarComentario(new Comentario("Ana Paula", "Muito interessante ver como o processo funciona."));
        video3.AdicionarComentario(new Comentario("Gustavo Santos", "Conteúdo bem informativo e organizado."));
        video3.AdicionarComentario(new Comentario("Thiago Oliveira", "Mostrou detalhes que quase ninguém explica."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.ExibirDetalhes();
        }
    }
}