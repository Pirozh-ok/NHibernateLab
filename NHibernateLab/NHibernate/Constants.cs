namespace NHibernateLab.NHibernate {
    public static class Constants {
        public const int NameMaxLen = 40;
        public const int NameMinLen = 2;
        public const int TopicNameMaxLen = 200;
        public const int MarkMaxValue = 100;
        public const int MarkMinValue = 1;
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
