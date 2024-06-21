namespace BDS.Application.Validators
{
    public static class ValidatorMethods
    {
        public static string MensagemValidator(string campo)
        {
            return $"O campo {campo} não pode ser vazio ou nulo.";
        }

        public static bool GuidValido(Guid guid)
        {
            return true;
        }
    }
}
