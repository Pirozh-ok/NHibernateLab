﻿namespace NHibernateLab.Entities {
    public class Mark : IEntity {
        public virtual int Id { get; set; }
        public virtual int ExamMark { get; set; }
        public virtual int DefendMark { get; set; }

        public virtual Student Student { get; set; }
    }
}
