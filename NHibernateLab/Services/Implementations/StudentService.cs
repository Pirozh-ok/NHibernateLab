using NHibernateLab.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHibernateLab.Services.Implementations {
    public class StudentService : EntityService<Student> {

        public override Task<Student> GetByIdAsync(int id) {
            throw new System.NotImplementedException();
        }

        public override Task<IList<Student>> SearchAsync(string text) {
            throw new System.NotImplementedException();
        }

        public override Task UpdateAsync(Student entity) {
            throw new System.NotImplementedException();
        }
    }
}
