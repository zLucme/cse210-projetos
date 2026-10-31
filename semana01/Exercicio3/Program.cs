using System;

class Program
{
    static void Main()
    {
        string jogarNovamente = "sim";

        while (string.Equals(jogarNovamente, "sim", StringComparison.OrdinalIgnoreCase))
        {
            int numeroMagico = Random.Shared.Next(1, 101);
            int palpite = -1;
            int tentativas = 0;

            while (palpite != numeroMagico)
            {
                Console.Write("Qual é o seu palpite? ");
                palpite = int.Parse(Console.ReadLine());
                tentativas++;

                if (palpite < numeroMagico)
                {
                    Console.WriteLine("Mais alto");
                }
                else if (palpite > numeroMagico)
                {
                    Console.WriteLine("Mais baixo");
                }
                else
                {
                    Console.WriteLine("Você adivinhou!");
                }
            }

            Console.WriteLine($"Você adivinhou em {tentativas} palpites!");

            Console.Write("Deseja jogar de novo? ");
            jogarNovamente = Console.ReadLine();
        }
    }
}