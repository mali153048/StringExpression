using System.Text.RegularExpressions;
using ULSolutions.Validators;
using static ULSolutions.Enums;

namespace ULSolutions.Services
{
    public class DmasService
    {

        public double Evaluate(string stringExpression)
        {
            if(!StringExpressionValidator.Validate(stringExpression))
            {
                throw new ArgumentException("String expression cannot be null/empty");
            }

            if (TryEvaluateDivision(stringExpression, out string expAfterDivision))
            {
                return Evaluate(expAfterDivision);
            }
            else if (TryEvaluateMultiplication(stringExpression, out string expAfterMultiplication))
            {
                return Evaluate(expAfterMultiplication);
            }
            else if (TryEvaluateAddition(stringExpression, out string expAfterAddition))
            {
                return Evaluate(expAfterAddition);
            }
            else if (TryEvaluateSubtraction(stringExpression, out string expAfterSubtraction))
            {
                return Evaluate(expAfterSubtraction);
            }
            else
            {
                return double.Parse(stringExpression);
            }


        }


        private bool TryEvaluateDivision(string stringExpression, out string updatedExpression)
        {
            string pattern = @"(\d+(\.\d+)?)\s*\/\s*(\d+(\.\d+)?)";

            updatedExpression = ExecuteOperation(pattern, stringExpression, Operator.Division);

            return stringExpression.Equals(updatedExpression) ? false : true;

        }

        private bool TryEvaluateMultiplication(string stringExpression, out string updatedExpression)
        {
            string pattern = @"(\d+(\.\d+)?)\s*\*\s*(\d+(\.\d+)?)";

            updatedExpression = ExecuteOperation(pattern, stringExpression, Operator.Multiplication);


            return stringExpression.Equals(updatedExpression) ? false : true;

        }

        private bool TryEvaluateAddition(string stringExpression, out string updatedExpression)
        {
            string pattern = @"(\d+(\.\d+)?)\s*\+\s*(\d+(\.\d+)?)";

            updatedExpression = ExecuteOperation(pattern, stringExpression, Operator.Addition);


            return stringExpression.Equals(updatedExpression) ? false : true;

        }

        private bool TryEvaluateSubtraction(string stringExpression, out string updatedExpression)
        {
            string pattern = @"(\d+(\.\d+)?)\s*\-\s*(\d+(\.\d+)?)";

            updatedExpression = ExecuteOperation(pattern, stringExpression, Operator.Subtraction);


            return stringExpression.Equals(updatedExpression) ? false : true;

        }


        private string ExecuteOperation(string pattern, string stringExpression, Operator @operator)
        {
            Match match = Regex.Match(stringExpression, pattern);
            if (!match.Success)
            {
                return stringExpression;
            }

            double.TryParse(match.Groups[1].Value, out double num1);
            double.TryParse(match.Groups[3].Value, out double num2);

            switch (@operator)
            {
                case Operator.None:
                    throw new ArgumentException("Invalid operator. Can only contain /, *, +, -");
                case Operator.Division:
                    var divisionResult = num1 / num2;
                    stringExpression = stringExpression.Replace(match.Value, divisionResult.ToString());
                    break;
                case Operator.Multiplication:
                    var multiplicationResult = num1 * num2;
                    stringExpression = stringExpression.Replace(match.Value, multiplicationResult.ToString());
                    break;
                case Operator.Addition:
                    var additionResult = num1 + num2;
                    stringExpression = stringExpression.Replace(match.Value, additionResult.ToString());
                    break;
                case Operator.Subtraction:
                    var subtractionResult = num1 - num2;
                    stringExpression = stringExpression.Replace(match.Value, subtractionResult.ToString());
                    break;
                default:
                    throw new ArgumentException("Invalid operator. Can only contain /, *, +, -");
            }

            return stringExpression;
        }
    }
}
