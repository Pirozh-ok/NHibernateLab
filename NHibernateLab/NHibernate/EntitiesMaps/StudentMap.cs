using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class StudentMap : ClassMap<Student> {
        public StudentMap() {
            Table("Students");

            Id(x => x.CreditBookNumber).CustomSqlType("Serial").GeneratedBy.Native();
            Map(x => x.FirstName).Length(Constants.NameMaxLen);
            Map(x => x.LastName).Length(Constants.NameMaxLen);
            Map(x => x.Patronymic).Length(Constants.NameMaxLen);

            HasOne(x => x.Mark).Cascade.All();
            HasOne(x => x.Topic).Cascade.All();

            References(x => x.Faculty).Column("FacultyId");
            References(x => x.Group).Column("GroupId");
        }
    }
}
