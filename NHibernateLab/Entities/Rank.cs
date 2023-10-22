﻿using System.Collections.Generic;

namespace NHibernateLab.Entities {
    public class Rank : IEntity {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        private IList<Teacher> _teachers;
        public virtual IList<Teacher> Teachers {
            get {
                return _teachers ?? (_teachers = new List<Teacher>());
            }
            set { _teachers = value; }
        }
    }
}
