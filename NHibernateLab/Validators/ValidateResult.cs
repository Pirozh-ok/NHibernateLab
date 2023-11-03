namespace NHibernateLab.Helpers {
    public class ValidateResult {
        public ValidateResult(string error) {
            IsValid = false;
            Error = error;
        }

        public ValidateResult() {
            IsValid = true;
            Error = string.Empty;
        }

        public bool IsValid { get; set; }
        public string Error { get; set; }
    }
}
