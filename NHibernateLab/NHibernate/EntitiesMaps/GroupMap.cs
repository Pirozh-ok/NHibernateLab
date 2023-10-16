using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class GroupMap : ClassMap<Group> {
        public GroupMap() {
            Table("Groups");

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Length(40).Not.Nullable();

            HasMany(x => x.Students)
                    .KeyColumn("GroupId")
                    .Inverse()
                    .Cascade.All();
        }
    }
}
