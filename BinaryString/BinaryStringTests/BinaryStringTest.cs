using BinaryString;
using NUnit.Framework;
using Shouldly;

namespace BinaryStringTests;

public class BinaryStringTest
{
    [Test]
    public void IsStringGood_WithNullInputString_ShouldThrowException()
    {
        // arrange, act, assert
        Should.Throw<ArgumentNullException>(() => BinaryStringValidator.IsStringGood(null));
    }
    
    [Test]
    public void IsStringGood_WithUnknownCharacter_ShouldThrowException()
    {
        // arrange, act, assert
        Should.Throw<ArgumentException>(() => BinaryStringValidator.IsStringGood("\0"));
    }
    
    [Test]
    [TestCase("", true)]
    [TestCase("10", true)]
    [TestCase("1111100000", true)]
    [TestCase("1", false)]
    [TestCase("101", false)]
    [TestCase("01", false)]
    [TestCase("1001", false)]
    [TestCase("1111000001", false)]
    public void IsStringGood_WithValidBinaryString_ShouldTestTheInputString(string binaryString, bool isGood)
    {
        // arrange, act
        var result = BinaryStringValidator.IsStringGood(binaryString);

        // assert
        result.ShouldBe(isGood);
    }
}
