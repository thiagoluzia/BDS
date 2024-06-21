namespace BDS.Core.ValueObjects
{
    public record Endereco
    {
        public Endereco(string? logradouro,
            string? cidade,
            string? bairro,
            string? uF,
            string? cEP)
        { }

    }
}
