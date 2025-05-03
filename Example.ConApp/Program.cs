
using Yod.Lib.Number;

var luckNumber = 45.0;

var valLuckyNumber = Yod<double>.Number(luckNumber)
    .Min(30, "Your lucky number cannot be something lower than 30, you are not a weakling!")
    .Max(100)
    .NotFollowing()
    .ApproximatelyEquals(42.0, 0.001)
    .Validate();

Console.WriteLine(valLuckyNumber);

foreach (var problem in valLuckyNumber.Problems)
{
    Console.WriteLine(problem);
}