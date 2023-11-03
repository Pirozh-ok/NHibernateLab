using NHibernate.Util;
using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using NHibernateLab.UI;
using NHibernateLab.Validators;
using System.Linq;

namespace NHibernateLab.Helpers {
    public class StudentValidator : IValidator<Student>{
        public ValidateResult Validate(Student obj) {
            if (obj == null) {
                return new ValidateResult("Объект null");
            }

            var check1 = ValidateFirsName(obj.FirstName);
            if (!check1.IsValid) {
                return new ValidateResult(check1.Error);
            }

            var check2 = ValidateLastName(obj.LastName);
            if (!check2.IsValid) {
                return new ValidateResult(check2.Error);
            }

            var check3 = ValidatePatronymic(obj.Patronymic);
            if (!check3.IsValid) {
                return new ValidateResult(check3.Error);
            }

            return new ValidateResult();
        }

        public ValidateResult ValidateFirsName(string name) {
            if (string.IsNullOrEmpty(name)) {
                return new ValidateResult(MessagesConstants.FIRSTNAME_IS_EMPTY);
            }

            if (name.Any(x => !char.IsLetter(x))) {
                return new ValidateResult(MessagesConstants.FIRSTNAME_CONTAINS_DIGIT);
            }

            if (name.Length > Constants.NameMaxLen) {
                return new ValidateResult(MessagesConstants.FIRSTNAME_LENGTH_MORE_MAX);
            }

            if (name.Length < Constants.NameMinLen) {
                return new ValidateResult(MessagesConstants.FIRSTNAME_LENGTH_LESS_MIN);
            }

            return new ValidateResult();
        }

        public ValidateResult ValidateLastName(string lastname) {
            if (string.IsNullOrEmpty(lastname)) {
                return new ValidateResult(MessagesConstants.LASTNAME_IS_EMPTY);
            }

            if (lastname.Any(x => !char.IsLetter(x))) {
                return new ValidateResult(MessagesConstants.LASTNAME_CONTAINS_DIGIT);
            }

            if (lastname.Length > Constants.NameMaxLen) {
                return new ValidateResult(MessagesConstants.LASTNAME_LENGTH_MORE_MAX);
            }

            if (lastname.Length < Constants.NameMinLen) {
                return new ValidateResult(MessagesConstants.LASTNAME_LENGTH_LESS_MIN);
            }

            return new ValidateResult();
        }

        public ValidateResult ValidatePatronymic(string patronymic) {
            if (string.IsNullOrEmpty(patronymic)) {
                return new ValidateResult(MessagesConstants.PATRONYMIC_IS_EMPTY);
            }

            if (patronymic.Any(x => !char.IsLetter(x))) {
                return new ValidateResult(MessagesConstants.PATRONYMIC_CONTAINS_DIGIT);
            }

            if (patronymic.Length > Constants.NameMaxLen) {
                return new ValidateResult(MessagesConstants.PATRONYMIC_LENGTH_MORE_MAX);
            }

            if (patronymic.Length < Constants.NameMinLen) {
                return new ValidateResult(MessagesConstants.PATRONYMIC_LENGTH_LESS_MIN);
            }

            return new ValidateResult();
        }
    }
}
