namespace NHibernateLab.Entities {
    public class Teacher : IEntity {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Patronymic { get; set; }           
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }

        public virtual Department Department { get; set; }
        public virtual Degree Degree { get; set; }
        public virtual Rank Rank { get; set; }

    }
}
