namespace SampleNamespace;

public class SumCalculatorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestSumIntegers()
    {
        // Arrange
        int first_number = 2;
        int second_number = 3;
        int expected_result = 5;

        // Act
        int result = SumCalculator.SumIntegers(first_number, second_number);

        // Assert
        Assert.AreEqual(result, expected_result);
    }
}