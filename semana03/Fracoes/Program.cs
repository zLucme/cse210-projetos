using System;

namespace Fracoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Fracao f1 = new Fracao();
            Fracao f2 = new Fracao(5);
            Fracao f3 = new Fracao(3, 4);
            Fracao f4 = new Fracao(1, 3);

            ExibirResultados(f1);
            ExibirResultados(f2);
            ExibirResultados(f3);
            ExibirResultados(f4);

            Console.WriteLine("\n--- Testando Setters e Getters ---");
            Fracao fTeste = new Fracao();
            Console.WriteLine($"Valor inicial: {fTeste.ObterFracaoEmTexto()}");
            
            fTeste.DefinirNumerador(7);
            fTeste.DefinirDenominador(8);
            
            Console.WriteLine($"Novo numerador obtido: {fTeste.ObterNumerador()}");
            Console.WriteLine($"Novo denominador obtido: {fTeste.ObterDenominador()}");
            Console.WriteLine($"Nova fração em texto: {fTeste.ObterFracaoEmTexto()}");
        }

        static void ExibirResultados(Fracao fracao)
        {
            Console.WriteLine(fracao.ObterFracaoEmTexto());
            Console.WriteLine(fracao.ObterFracaoEmDecimal());
        }
    }
}