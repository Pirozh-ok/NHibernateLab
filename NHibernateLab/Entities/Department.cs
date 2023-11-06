using System.Collections.Generic;

namespace NHibernateLab.Entities {
    public class Department : BaseDictionaryEntity {
        private IList<Teacher> _teachers;
        public virtual IList<Teacher> Teachers {
            get {
                return _teachers ?? (_teachers = new List<Teacher>());
            }
            set { _teachers = value; }
        }
    }
}
