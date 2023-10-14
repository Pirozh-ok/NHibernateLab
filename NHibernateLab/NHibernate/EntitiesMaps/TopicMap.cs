using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class TopicMap : ClassMap<Topic>{
        public TopicMap() {
            Table("Topics");

            Id(x => x.Id);

            Map(x => x.Name)
                .Length(100)
                .Not.Nullable();

            HasOne(x => x.Teacher);

            HasOne(x => x.Student);
        }
    }
}
