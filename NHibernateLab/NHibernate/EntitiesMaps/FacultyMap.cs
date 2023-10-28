using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class FacultyMap : ClassMap<Faculty> {
        public FacultyMap() {
            Table("Faculties");

            Id(x => x.Id).CustomSqlType("Serial").GeneratedBy.Native();
            Map(x => x.Name).Length(Constants.NameMaxLen).Not.Nullable();

            HasMany(x => x.Students)
                .KeyColumn("FacultyId")
                .Inverse()
                .Cascade.All();
        }
    }
}
