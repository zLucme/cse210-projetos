using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite a sua nota percentual: ");
        int notaNumerica = int.Parse(Console.ReadLine());

        string letra;

        if (notaNumerica >= 90)
        {
            letra = "A";
        }
        else if (notaNumerica >= 80)
        {
            letra = "B";
        }
        else if (notaNumerica >= 70)
        {
            letra = "C";
        }
        else if (notaNumerica >= 60)
        {
            letra = "D";
        }
        else
        {
            letra = "F";
        }

        int ultimoDigito = notaNumerica % 10;
        string sinal = "";

        if (ultimoDigito >= 7)
        {
            sinal = "+";
        }
        else if (ultimoDigito < 3)
        {
            sinal = "-";
        }

        if (letra == "A" && sinal == "+")
        {
            sinal = "";
        }
        else if (letra == "F")
        {
            sinal = "";
        }

        if (notaNumerica >= 100)
        {
            sinal = "";
        }

        Console.WriteLine($"Nota final: {letra}{sinal}");

        if (notaNumerica >= 70)
        {
            Console.WriteLine("Parabéns, você foi aprovado no curso!");
        }
        else
        {
            Console.WriteLine("Você não conseguiu a aprovação desta vez. Continue se esforçando para a próxima!");
        }
    }
}