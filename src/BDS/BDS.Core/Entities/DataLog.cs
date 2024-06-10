namespace BDS.Core.Entities
{
    public class DataLog
    {
        public DataLog(DateTime dataAlteracao, DateTime dataInclusao, string valorAnterior, string valorAtual, string usuarioLogado)
        {
            DataAlteracao = DateTime.MinValue;
            DataInclusao = DateTime.UtcNow;
            ValorAnterior = valorAnterior;
            ValorAtual = valorAtual;
            UsuarioLogado = usuarioLogado;
        }


        public DateTime DataAlteracao { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public string ValorAnterior { get; private set; }
        public string ValorAtual { get; private set; }
        public string UsuarioLogado { get; private set; }


        public void AtualizaDataLog(string valorAnterior, string valorAtual, string usuarioLogado)
        {
            ValorAnterior = valorAnterior;
            ValorAtual = valorAtual;
            UsuarioLogado = usuarioLogado;
        }
    }
}
