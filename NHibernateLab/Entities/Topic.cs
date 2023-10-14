using System;

namespace NHibernateLab.Entities {
    public class Topic {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
    }
}
