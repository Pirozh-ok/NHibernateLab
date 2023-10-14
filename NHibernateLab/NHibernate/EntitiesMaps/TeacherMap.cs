using FluentNHibernate.Mapping;
using NHibernate.Proxy;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class TeacherMap : ClassMap<Teacher> {
        public TeacherMap() {
            Table("Teachers");

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

            Map(x => x.Phone)
                .Length(15)
                .Unique();

            Map(x => x.Email)
                .Length(30)
                .Unique();

            References(x => x.Degree)
                .Column("Degree");

            References(x => x.Department)
                .Column("Department");

            References(x => x.Rank)
                .Column("Rank");
        }
    }
}
