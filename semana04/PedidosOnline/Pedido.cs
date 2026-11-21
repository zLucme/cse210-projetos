using System.Collections.Generic;
using System.Text;

public class Pedido
{
    private Cliente _cliente;
    private List<Produto> _produtos;

    public Pedido(Cliente cliente)
    {
        _cliente = cliente;
        _produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        _produtos.Add(produto);
    }

    public double CalcularSubtotal()
    {
        double subtotal = 0;
        foreach (Produto produto in _produtos)
        {
            subtotal += produto.CalcularCustoTotal();
        }
        return subtotal;
    }

    public double CalcularEnvio()
    {
        return _cliente.MoraNosEua() ? 5.00 : 35.00;
    }

    public double CalcularTotal()
    {
        return CalcularSubtotal() + CalcularEnvio();
    }

    public string ObterEtiquetaEmbalagem()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("ETIQUETA DE EMBALAGEM");
        foreach (Produto produto in _produtos)
        {
            sb.AppendLine($"- {produto.ObterResumoEtiqueta()}");
        }
        return sb.ToString().TrimEnd();
    }

    public string ObterEtiquetaEnvio()
    {
        return $"ETIQUETA DE ENVIO\n{_cliente.ObterNome()}\n{_cliente.ObterEnderecoCompleto()}";
    }
}