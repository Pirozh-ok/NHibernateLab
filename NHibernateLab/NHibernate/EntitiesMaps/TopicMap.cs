using FluentNHibernate.Mapping;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate.EntitiesMaps {
    public class TopicMap : ClassMap<Topic>{
        public TopicMap() {
            Table("Topics");

            Id(x => x.Id).CustomSqlType("Serial").GeneratedBy.Native();
            Map(x => x.Name).Length(40).Not.Nullable();

            References(x => x.Teacher).Column("TeacherId");
            References(x => x.Student).Column("CreditBookNumber");
        }
    }
}
