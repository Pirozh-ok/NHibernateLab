using FluentNHibernate.Mapping;
using NHibernate.Proxy;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class TeacherMap : ClassMap<Teacher> {
        public TeacherMap() {
            Table("Teachers");

            Id(x => x.Id).CustomSqlType("Serial").GeneratedBy.Native();
            Map(x => x.FirstName).Length(40);
            Map(x => x.LastName).Length(40);
            Map(x => x.Patronymic).Length(40);
            Map(x => x.Phone).Length(40).Unique();
            Map(x => x.Email).Length(40).Unique();

            References(x => x.Department).Column("DepartmentId");
            References(x => x.Degree).Column("DegreeId");
            References(x => x.Rank).Column("RankId");
        }
    }
}
