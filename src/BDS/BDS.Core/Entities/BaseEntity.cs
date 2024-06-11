namespace BDS.Core.Entities
{
    public abstract class  BaseEntity
    {
        public Guid Id { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; private set; }


        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            Ativo = true;
            DataCriacao = DateTime.Now;
        }


        public void Deletar()
        {
            Ativo = false;
        }
    }
}
