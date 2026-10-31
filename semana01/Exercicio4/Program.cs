using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numeros = [];

        Console.WriteLine("Insira uma lista de números e digite 0 quando terminar.");

        while (true)
        {
            Console.Write("Insira o número: ");
            int numeroInserido = int.Parse(Console.ReadLine());

            if (numeroInserido == 0)
            {
                break;
            }

            numeros.Add(numeroInserido);
        }

        int soma = 0;
        int maior = numeros[0];
        int menorPositivo = int.MaxValue;

        foreach (int numero in numeros)
        {
            soma += numero;

            if (numero > maior)
            {
                maior = numero;
            }

            if (numero > 0 && numero < menorPositivo)
            {
                menorPositivo = numero;
            }
        }

        double media = (double)soma / numeros.Count;

        Console.WriteLine($"A soma é: {soma}");
        Console.WriteLine($"A média é: {media}");
        Console.WriteLine($"O maior número é: {maior}");

        if (menorPositivo != int.MaxValue)
        {
            Console.WriteLine($"O menor número positivo é: {menorPositivo}");
        }

        numeros.Sort();

        Console.WriteLine("A lista reordenada é:");
        foreach (int numero in numeros)
        {
            Console.WriteLine(numero);
        }
    }
}