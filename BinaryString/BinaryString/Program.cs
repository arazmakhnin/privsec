using BinaryString;

Console.Write("Enter binary string: ");
var line = Console.ReadLine();
var isGood = BinaryStringValidator.IsStringGood(line);
Console.WriteLine(isGood ? "String is good" : "String is not good");