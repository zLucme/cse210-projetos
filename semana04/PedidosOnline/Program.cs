using System;

class Program
{
    static void Main(string[] args)
    {
        Endereco enderecoEua = new Endereco("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Cliente clienteEua = new Cliente("Lucas Almeida", enderecoEua);
        Pedido pedidoEua = new Pedido(clienteEua);
        pedidoEua.AdicionarProduto(new Produto("Teclado Mecânico", "PRD-101", 89.90, 1));
        pedidoEua.AdicionarProduto(new Produto("Mouse Sem Fio", "PRD-204", 34.50, 2));

        Console.WriteLine(pedidoEua.ObterEtiquetaEmbalagem());
        Console.WriteLine();
        Console.WriteLine(pedidoEua.ObterEtiquetaEnvio());
        Console.WriteLine($"Subtotal: ${pedidoEua.CalcularSubtotal():F2}");
        Console.WriteLine($"Frete: ${pedidoEua.CalcularEnvio():F2}");
        Console.WriteLine($"Total: ${pedidoEua.CalcularTotal():F2}");

        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();

        Endereco enderecoBrasil = new Endereco("Rua das Flores, 120", "Campinas", "SP", "Brasil");
        Cliente clienteBrasil = new Cliente("Mariana Costa", enderecoBrasil);
        Pedido pedidoBrasil = new Pedido(clienteBrasil);
        pedidoBrasil.AdicionarProduto(new Produto("Fone de Ouvido", "PRD-309", 59.00, 1));
        pedidoBrasil.AdicionarProduto(new Produto("Suporte de Notebook", "PRD-412", 28.00, 1));

        Console.WriteLine(pedidoBrasil.ObterEtiquetaEmbalagem());
        Console.WriteLine();
        Console.WriteLine(pedidoBrasil.ObterEtiquetaEnvio());
        Console.WriteLine($"Subtotal: ${pedidoBrasil.CalcularSubtotal():F2}");
        Console.WriteLine($"Frete: ${pedidoBrasil.CalcularEnvio():F2}");
        Console.WriteLine($"Total: ${pedidoBrasil.CalcularTotal():F2}");
    }
}