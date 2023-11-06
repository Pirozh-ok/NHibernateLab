using NHibernateLab.Entities;
using NHibernateLab.Helpers;
using NHibernateLab.NHibernate;
using NHibernateLab.UI;

namespace NHibernateLab.Validators {
    public class DictionaryEntityValidator : IValidator<BaseDictionaryEntity> {
        public DictionaryEntityValidator() { }

        public ValidateResult Validate(BaseDictionaryEntity obj) {
            if (obj == null) {
                return new ValidateResult("Объект null");
            }

            var check1 = ValidateName(obj.Name);
            if (!check1.IsValid) {
                return new ValidateResult(check1.Error);
            }

            return new ValidateResult();
        }

        public ValidateResult ValidateName(string name) {
            if (string.IsNullOrEmpty(name)) {
                return new ValidateResult(MessagesConstants.NAME_IS_EMPTY);
            }

            if (name.Length > Constants.NameMaxLen) {
                return new ValidateResult(MessagesConstants.NAME_LENGTH_MORE_MAX);
            }

            if (name.Length < Constants.NameMinLen) {
                return new ValidateResult(MessagesConstants.NAME_LENGTH_LESS_MIN);
            }

            return new ValidateResult();
        }
    }
}
