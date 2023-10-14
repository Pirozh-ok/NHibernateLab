using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class MarkMap : ClassMap<Mark>{
        public MarkMap() {
            Table("Marks");

            Id(x => x.Id);

            Map(x => x.ExamMark);

            Map(x => x.DefendMark);

            HasOne(x => x.Student);
        }
    }
}
