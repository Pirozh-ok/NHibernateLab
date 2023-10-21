using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class DegreeMap : ClassMap<Degree> {
        public DegreeMap() {
            Table("Degrees");

            Id(x => x.Id).CustomSqlType("Serial").GeneratedBy.Native();
            Map(x => x.Name).Length(40).Not.Nullable();

            HasMany(x => x.Teachers)
                .Inverse()
                .Cascade.All()
                .KeyColumn("DegreeId");
        }
    }
}
