using System.Collections.Generic;

namespace NHibernateLab.Entities {
    public class Group : IEntity {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }


        private IList<Student> _students;
        public virtual IList<Student> Students {
            get {
                return _students ?? (_students = new List<Student>());
            }
            set { _students = value; }
        }
    }
}
