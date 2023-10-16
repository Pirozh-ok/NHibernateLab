using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class MarkMap : ClassMap<Mark> {
        public MarkMap() {
            Table("Marks");

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ExamMark).CustomSqlType("int CHECK (ExamMark >= 0 AND ExamMark <= 100)").Not.Nullable();
            Map(x => x.DefendMark).CustomSqlType("int CHECK (DefendMark >= 0 AND DefendMark <= 100)").Not.Nullable();

            References(x => x.Student).Column("StudentId");
        }
    }
}
