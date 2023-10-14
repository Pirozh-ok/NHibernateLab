using System;

namespace NHibernateLab.Entities {
    public class Mark {
        public virtual Guid Id { get; set; }
        public virtual uint ExamMark { get; set; }
        public virtual uint DefendMark { get; set; }

        public virtual Student Student { get; set; }
    }
}
