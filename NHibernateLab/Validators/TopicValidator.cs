using NHibernateLab.Entities;
using NHibernateLab.Helpers;
using NHibernateLab.NHibernate;
using NHibernateLab.UI;
using System.Linq;

namespace NHibernateLab.Validators {
    public class TopicValidator : IValidator<Topic> {
        public ValidateResult Validate(Topic obj) {
            if (obj == null) {
                return new ValidateResult("Объект null");
            }

            var checkName = ValidateTopicName(obj.Name);
            if (!checkName.IsValid) {
                return new ValidateResult(checkName.Error);
            }

            return new ValidateResult();
        }

        public ValidateResult ValidateTopicName(string name) {
            if (string.IsNullOrEmpty(name)) {
                return new ValidateResult(MessagesConstants.NAME_IS_EMPTY);
            }

            if (name.Length > Constants.TopicNameMaxLen) {
                return new ValidateResult(MessagesConstants.NAME_LENGTH_MORE_MAX);
            }

            if (name.Length < Constants.NameMinLen) {
                return new ValidateResult(MessagesConstants.NAME_LENGTH_LESS_MIN);
            }

            return new ValidateResult();
        }
    }
}
