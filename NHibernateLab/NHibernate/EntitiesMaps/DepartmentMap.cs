using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class DepartmentMap : ClassMap<Department> {
        public DepartmentMap() {
            Table("Departments");

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Length(40).Not.Nullable();

            HasMany(x => x.Teachers)
                .Inverse()
                .Cascade.All()
                .KeyColumn("DepartmentId");
        }
    }
}
