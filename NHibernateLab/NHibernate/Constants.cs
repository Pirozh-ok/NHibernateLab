namespace NHibernateLab.NHibernate {
    public static class Constants {
        public const int NameMaxLen = 40;
        public const int NameMinLen = 2;
    }

    public enum EntityType {
        Student,
        Teacher,
        Topic,
        Mark,
        Group,
        Department,
        Faculty,
        Rank,
        Degree
    };
}
