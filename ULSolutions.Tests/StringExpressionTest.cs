using ULSolutions.Services;

namespace ULSolutions.Test
{
    public class StringExpressionTest
    {
        [Fact]
        public void EvaluateNullEmptyExpression_ShouldThrowException()
        {
            DmasService dmasService = new DmasService();

            Assert.Throws<ArgumentException>(() => dmasService.Evaluate(string.Empty));
        }

        [Fact]
        public void EvaluateInvalidExpression_ShouldThrowException()
        {
            DmasService dmasService = new DmasService();

            Assert.Throws<ArgumentException>(() => dmasService.Evaluate("*4+5/2-1"));
        }

        [Fact]
        public void EvaluateValidExpressionWithAdditionAndMultiplication_ShouldEvaluate()
        {
            DmasService dmasService = new DmasService();

            var serviceResult = dmasService.Evaluate("4+5*2");
            double calculatedResult = 4 + (5 * 2);

            Assert.Equal(serviceResult, calculatedResult);
        }

        [Fact]
        public void EvaluateValidExpressionWithAdditionAndDivision_ShouldEvaluate()
        {
            DmasService dmasService = new DmasService();

            var serviceResult = dmasService.Evaluate("4+5/2");
            double calculatedResult = (4 + ((double)5 / 2));

            Assert.Equal(serviceResult, calculatedResult);
        }

        [Fact]
        public void EvaluateValidExpressionWithAdditionDivisionSubtraction_ShouldEvaluate()
        {
            DmasService dmasService = new DmasService();

            var serviceResult = dmasService.Evaluate("4+5/2-1");
            double calculatedResult = 4 + ((double)5 / 2) - 1;

            Assert.Equal(serviceResult, calculatedResult);
        }
    }
}