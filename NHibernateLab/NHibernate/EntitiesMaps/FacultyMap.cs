using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class FacultyMap : ClassMap<Faculty> {
        public FacultyMap() {
            Table("Faculties");

            Id(x => x.Id);

            Map(x => x.Name)
                .Length(40)
                .Not.Nullable();

            HasMany(x => x.Students)
                .Inverse()
                .Cascade.All()
                .KeyColumn("Faculty");
        }
    }
}
