using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class StudentMap : ClassMap<Student> {
        public StudentMap() {
            Table("Students");

            Id(x => x.Id);

            Map(x => x.FirstName)
                .Length(40)
                .Not.Nullable();

            Map(x => x.LastName)
                .Length(40)
                .Not.Nullable();

            Map(x => x.Patronymic)
                .Length(40)
                .Not.Nullable();

            References(x => x.Faculty)
                .Column("Faculty");

            References(x => x.Group)
                .Column("Group");

            HasOne(x => x.Mark)
                .Cascade.All()
                .Constrained();

            HasOne(x => x.Topic)
                .Cascade.All()
                .Constrained();
        }
    }
}
