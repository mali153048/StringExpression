namespace ULSolutions.Validators
{
    public static class StringExpressionValidator
    {
        public static bool Validate(string expression)
        {
            if(string.IsNullOrWhiteSpace(expression)) return false;

            if (!int.TryParse(expression[0].ToString(), out _) 
                || !int.TryParse(expression[expression.Length-1].ToString(), out _))
            {
                return false;
            }
            return true;
        }
    }
}
