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
             "WHERE " +
             "s.FirstName LIKE :searchText OR " +
             "s.LastName LIKE :searchText OR " +
             "s.Patronymic LIKE :searchText OR " +
             "f.FacultyName LIKE :searchText OR " +
             "g.GroupName LIKE :searchText";

                IQuery query = session.CreateQuery(hql);
                query.SetString("searchText", $"%{text}%");

                return await query.ListAsync<Student>();
            }
        }

        public async override Task UpdateAsync(Student entity) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                string hql = "UPDATE Student s " +
             "SET s.FirstName = :newFirstName, " +
             "s.LastName = :newLastName, " +
             "s.Patronymic = :newPatronymic, " +
             "s.Faculty = :newFaculty, " +
             "s.Group = :newGroup " +
             "WHERE s.CreditBookNumber = :creditBookNumber";

                IQuery query = session.CreateQuery(hql);
                query.SetString("newFirstName", entity.FirstName);
                query.SetString("newLastName", entity.LastName);
                query.SetString("newPatronymic", entity.Patronymic);
                query.SetEntity("newFaculty", entity.Faculty);
                query.SetEntity("newGroup", entity.Group);
                query.SetInt32("creditBookNumber", entity.CreditBookNumber);

                int updatedCount = await query.ExecuteUpdateAsync();
            }
        }
    }
}