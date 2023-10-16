using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class RankMap : ClassMap<Rank> {
        public RankMap() {
            Table("Ranks");

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Length(40).Not.Nullable();

            HasMany(x => x.Teachers)
                .KeyColumn("RankId")
                .Inverse()
                .Cascade.All();
        }
    }
}