using NHibernate;
using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Implementations {
    public class StudentService : EntityService<Student> {
        public async override Task<Student> GetByIdAsync(int id) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = $"FROM Student WHERE  = :creditbooknumber";

                IQuery query = session.CreateQuery(hql);
                query.SetInt32("creditbooknumber", id);

                return await query.UniqueResultAsync<Student>();
            }
        }

        public override async Task<IList<Student>> GetAllAsync() {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM Student s " +
             "LEFT JOIN FETCH s.Faculty f " +
             "LEFT JOIN FETCH s.Group g " +
             "ORDER BY s.CreditBookNumber";

                IQuery query = session.CreateQuery(hql);
                return await query.ListAsync<Student>();
            }
        }

        public async override Task<IList<Student>> SearchAsync(string text) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "FROM Student s " +
                    "LEFT JOIN FETCH s.Faculty f " +
                    "LEFT JOIN FETCH s.Group g " +
                    "WHERE LOWER(s.FirstName) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.LastName) LIKE LOWER(:searchText) OR " +
                    "LOWER(s.Patronymic) LIKE LOWER(:searchText) OR " +
                    "LOWER(f.Name) LIKE LOWER(:searchText) OR " +
                    "LOWER(g.Name) LIKE LOWER(:searchText)";

                IQuery query = session.CreateQuery(hql);
                query.SetString("searchText", $"%{text}%");

                return await query.ListAsync<Student>();
            }
        }

        public async override Task UpdateAsync(Student entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    // Получите объект Student, который вы хотите обновить, например, по его идентификатору
                    Student studentToUpdate = session.Get<Student>(entity.CreditBookNumber);

                    // Внесите изменения в свойства сущности
                    studentToUpdate.FirstName = entity.FirstName;
                    studentToUpdate.LastName = entity.LastName;

                    // Обновите связанные сущности, например, Faculty и Group
                    Faculty newFaculty = session.Get<Faculty>(entity.Faculty.Id);
                    Group newGroup = session.Get<Group>(entity.Group.Id);
                    studentToUpdate.Faculty = newFaculty;
                    studentToUpdate.Group = newGroup;

                    // Сохраните обновленную сущность в базе данных
                    await session.UpdateAsync(studentToUpdate);

                    await transaction.CommitAsync();
                }
            }
        }
    }
}