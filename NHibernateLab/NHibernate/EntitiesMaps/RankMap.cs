using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class RankMap : ClassMap<Rank> {
        public RankMap() {
            Table("Ranks");

            Id(x => x.Id).CustomSqlType("Serial").GeneratedBy.Native();
            Map(x => x.Name).Length(Constants.NameMaxLen).Not.Nullable();

            HasMany(x => x.Teachers)
                .KeyColumn("RankId")
                .Inverse()
                .Cascade.All();
        }
    }
}