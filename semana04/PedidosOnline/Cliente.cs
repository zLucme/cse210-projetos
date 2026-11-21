public class Cliente
{
    private string _nome;
    private Endereco _endereco;

    public Cliente(string nome, Endereco endereco)
    {
        _nome = nome;
        _endereco = endereco;
    }

    public bool MoraNosEua()
    {
        return _endereco.EstaNosEua();
    }

    public string ObterNome()
    {
        return _nome;
    }

    public string ObterEnderecoCompleto()
    {
        return _endereco.ObterEnderecoFormatado();
    }
}