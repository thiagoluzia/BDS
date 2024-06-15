namespace BDS.Core.Entities
{
    public abstract class  BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public bool Ativo { get; private set; }


        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            DataInclusao = DateTime.Now;
            Ativo = true;
        }

        public void Deletar()
        {
            if (Ativo)
            {
                Ativo = false;
            }
            
        }
    }
}
