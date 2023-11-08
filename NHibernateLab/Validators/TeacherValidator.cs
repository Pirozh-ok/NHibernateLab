using NHibernateLab.Entities;
using NHibernateLab.Helpers;
using NHibernateLab.NHibernate;
using NHibernateLab.UI;
using System.Linq;

namespace NHibernateLab.Validators {
    public class TeacherValidator : IValidator<Teacher> {
        public ValidateResult Validate(Teacher obj) {
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

            var check4 = ValidateEmail(obj.Email);
            if (!check4.IsValid) {
                return new ValidateResult(check4.Error);
            }

            var check5 = ValidatePhone(obj.Patronymic);
            if (!check5.IsValid) {
                return new ValidateResult(check5.Error);
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

        public ValidateResult ValidateEmail(string email) {
            if (string.IsNullOrEmpty(email)) {
                return new ValidateResult(MessagesConstants.EMAIL_IS_INCORRECT);
            }

            return new ValidateResult();
        }

        public ValidateResult ValidatePhone(string phone) {
            if (string.IsNullOrEmpty(phone)) {
                return new ValidateResult(MessagesConstants.PHONE_IS_INCORRECT);
            }

            return new ValidateResult();
        }
    }
}
