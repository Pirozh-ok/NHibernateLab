using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class DegreeMap : ClassMap<Degree> {
        public DegreeMap() {
            Table("Degrees");

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Length(40).Not.Nullable();

            HasMany(x => x.Teachers)
                .Inverse()
                .Cascade.All()
                .KeyColumn("DegreeId");
        }
    }
}
