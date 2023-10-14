using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernateLab.NHibernate.EntitiesMaps;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateLab.NHibernate {
    public static class NHibernateHelper {
        public static ISession OpenSession() {
            ISessionFactory sessionFactory = Fluently.Configure()
     .Database(PostgreSQLConfiguration.Standard.ConnectionString("User Id=postgres;Password=admin;Host=localhost;Port=5432;Database=Students;").ShowSql()
            )
            .Mappings(m => m.FluentMappings
            .AddFromAssemblyOf<DegreeMap>()
            .AddFromAssemblyOf<DepartmentMap>()
            .AddFromAssemblyOf<FacultyMap>()
            .AddFromAssemblyOf<GroupMap>()
            .AddFromAssemblyOf<MarkMap>()
            .AddFromAssemblyOf<RankMap>()
            .AddFromAssemblyOf<StudentMap>()
            .AddFromAssemblyOf<StudentMap>()
            .AddFromAssemblyOf<TeacherMap>()
            .AddFromAssemblyOf<TopicMap>())
            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
            .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
