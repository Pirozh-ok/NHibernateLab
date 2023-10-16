using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernateLab.NHibernate.EntitiesMaps;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Dialect;
using NHibernate.Cfg;
using NHibernateLab.Entities;

namespace NHibernateLab.NHibernate {
    public static class NHibernateHelper {

        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory {
            get {
                if (_sessionFactory == null) {
                    InitializeSessionFactory();
                }

                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory() {
            _sessionFactory = Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard.ConnectionString("User Id=postgres;Password=Yie4heech7kaiv;Host=localhost;Port=5432;Database=Students;")
                .Dialect<PostgreSQL82Dialect>()
                .ShowSql())
                .Mappings(m => m.FluentMappings
            .AddFromAssemblyOf<DegreeMap>()
            .AddFromAssemblyOf<DepartmentMap>()
            .AddFromAssemblyOf<FacultyMap>()
            .AddFromAssemblyOf<GroupMap>()
            .AddFromAssemblyOf<MarkMap>()
            .AddFromAssemblyOf<RankMap>()
            .AddFromAssemblyOf<StudentMap>()
            .AddFromAssemblyOf<TeacherMap>()
            .AddFromAssemblyOf<TopicMap>())
            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
            .BuildSessionFactory();
        }

        public static ISession OpenSession() {
            return SessionFactory.OpenSession();
        }

        public static void CreateDatabase() {
            var connectionString = "User Id=postgres;Password=Yie4heech7kaiv;Host=localhost;Port=5432;Database=Students;";

            var configuration = Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard.ConnectionString(connectionString)
                .ShowSql())
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<DegreeMap>()
                    .AddFromAssemblyOf<DepartmentMap>()
                    .AddFromAssemblyOf<FacultyMap>()
                    .AddFromAssemblyOf<GroupMap>()
                    .AddFromAssemblyOf<MarkMap>()
                    .AddFromAssemblyOf<RankMap>()
                    .AddFromAssemblyOf<StudentMap>()
                    .AddFromAssemblyOf<TeacherMap>()
                    .AddFromAssemblyOf<TopicMap>())
                    .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            _sessionFactory = configuration.BuildSessionFactory();
        }

        public static void RecreateTables() {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Degree).Assembly)
                .AddAssembly(typeof(Department).Assembly)
                .AddAssembly(typeof(Faculty).Assembly)
                .AddAssembly(typeof(Group).Assembly)
                .AddAssembly(typeof(Mark).Assembly)
                .AddAssembly(typeof(Rank).Assembly)
                .AddAssembly(typeof(Student).Assembly)
                .AddAssembly(typeof(Teacher).Assembly)
                .AddAssembly(typeof(Topic).Assembly);

            new SchemaExport(cfg).Execute(true, true, false);
        }
    }
}
