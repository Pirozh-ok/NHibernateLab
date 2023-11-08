using NHibernate;
using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Implementations {
    public class TopicService : EntityService<Topic> {
        public override async Task<IList<Topic>> GetAllAsync() {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM Topic topic " +
             "LEFT JOIN FETCH topic.Teacher teacher " +
             "LEFT JOIN FETCH topic.Student student " +
             "ORDER BY topic.Id";

                IQuery query = session.CreateQuery(hql);
                return await query.ListAsync<Topic>();
            }
        }

        public async override Task<IList<Topic>> SearchAsync(string text) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM Topic top " +
                    "LEFT JOIN FETCH top.Teacher t " +
                    "LEFT JOIN FETCH top.Student s " +
                    "WHERE " +
                    "LOWER(top.Name) LIKE LOWER(:searchText) OR " +
                    "LOWER(t.FirstName) LIKE LOWER(:searchText) OR " +
                    "LOWER(t.LastName) LIKE LOWER(:searchText) OR " +
                    "LOWER(t.Patronymic) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.FirstName) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.LastName) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.Patronymic) LIKE LOWER(:searchText)";

                IQuery query = session.CreateQuery(hql);
                query.SetString("searchText", $"%{text}%");

                return await query.ListAsync<Topic>();
            }
        }

        public override async Task UpdateAsync(Topic entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    Topic topicToUpdate = session.Get<Topic>(entity.Id);
                    topicToUpdate.Name = entity.Name;

                    Student newStudent = session.Get<Student>(entity.Student.CreditBookNumber);
                    Teacher newTeacher = session.Get<Teacher>(entity.Teacher.Id);
                    topicToUpdate.Teacher = newTeacher;
                    topicToUpdate.Student = newStudent;

                    await session.UpdateAsync(topicToUpdate);
                    await transaction.CommitAsync();
                }
            }
        }
    }
}
