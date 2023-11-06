namespace NHibernateLab.Entities {
    public abstract class BaseDictionaryEntity : IEntity {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
