using NHibernateLab.Entities;
using NHibernateLab.Helpers;

namespace NHibernateLab.Validators {
    public interface IValidator<T> where T : IEntity {
        ValidateResult Validate(T obj);
    }
}
