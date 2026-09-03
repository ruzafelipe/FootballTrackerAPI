namespace FootballTracker.Domain.Common
{

    /* chatgpt
    
    🧠 Por que isso existe?

        Todas as entidades têm identidade

        O protected set impede alteração externa

        O domínio controla seus próprios IDs

        📌 Mesmo que o banco use outro tipo depois, isso não muda o domínio.*/



    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        protected void SetUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
