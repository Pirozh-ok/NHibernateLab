using FluentNHibernate.Mapping;
using NHibernate.Proxy;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class TeacherMap : ClassMap<Teacher> {
        public TeacherMap() {
            Table("Teachers");

            Id(x => x.Id).CustomSqlType("Serial").GeneratedBy.Native();
            Map(x => x.FirstName).Length(Constants.NameMaxLen);
            Map(x => x.LastName).Length(Constants.NameMaxLen);
            Map(x => x.Patronymic).Length(Constants.NameMaxLen);
            Map(x => x.Phone).Length(Constants.NameMaxLen).Unique();
            Map(x => x.Email).Length(Constants.NameMaxLen).Unique();

            References(x => x.Department).Column("DepartmentId");
            References(x => x.Degree).Column("DegreeId");
            References(x => x.Rank).Column("RankId");
        }
    }
}
