﻿namespace NHibernateLab.Entities {
    public class Student : IEntity {
        public virtual int CreditBookNumber { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Patronymic { get; set; }

        public virtual Mark Mark { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Group Group { get; set; }
    }
}
