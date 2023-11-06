using System.Collections.Generic;

namespace NHibernateLab.Entities {
    public class Faculty : BaseDictionaryEntity {
        private IList<Student> _students;
        public virtual IList<Student> Students {
            get {
                return _students ?? (_students = new List<Student>());
            }
            set { _students = value; }
        }
    }
}
