namespace NHibernateLab.Entities {
    public class Topic : IEntity {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
    }
}
