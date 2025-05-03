// using Yod.Lib;
// using Yod.Lib.Char;
// using Yod.Lib.Number;

using Yod.Lib;
using Yod.Lib.Object;
using Yod.Lib.String;
//
// var luckNumber = 45.0;
//
// var valLuckyNumber = NumberValidation<double>.On(luckNumber)
//     .Min(30, "Your lucky number cannot be something lower than 30, you are not a weakling!")
//     .Not()
//     .Max(100)
//     .NotNextOnly()
//     .ApproximatelyEquals(42.0, 0.001)
//     .ApproximatelyEquals(45.0, 0.001)
//     .Validate();
//
// valLuckyNumber.Print();
//
// ////
// Console.WriteLine();
// ////
//
// var myInitial = 'a';
//
// var valMyInitial = CharValidation.On(myInitial)
//     .Lowercase()
//     .Equals('a')
//     .Validate();
//
// valMyInitial.Print();
//
// ////
// Console.WriteLine();
// ///
//
// var myString = " Hello there! :D        ";
//
// var valMyString = StringValidation.On(myString)
//     .Trim()
//     .Min(5)
//     .Max(20)
//     .Transform(x => x + "    ")
//     .Trim()
//     .RegexExactMatch("([a-zA-Z0-9]+ [a-zA-Z0-9]+)! :D")
//     .Validate();
//
// valMyString.Print();
//
// ////
// Console.WriteLine();
// ///
//
// var myNumberInput = " -5345  ";
//
// var valMyNumberInput = StringValidation.On(myNumberInput)
//     .Int(out _)
//     .Validate();
//
// valMyNumberInput.Print();
//
// ////
// Console.WriteLine();
// ///
//
// var myEmail = "ya+nni+my.cool.exception@outlo.o.k.at";
//
// var valMyEmail = StringValidation.On(myEmail)
//     .Email()
//     .Validate();
//
// valMyEmail.Print();
//
// ////
// Console.WriteLine();
// ///
//
// var myPhoneNumber = "+43 677 62601376";
//
// var valMyPhoneNumber = StringValidation.On(myPhoneNumber)
//     .PhoneNumber()
//     .Validate();
//
// valMyPhoneNumber.Print();
//
// ////
// Console.WriteLine();
//
// ///

var yanni = new
{
    FirstName = "Yanni",
    LastName = "Alshoufi",
    LocationStr = new
    {
        X = "2345",
        Y = "543",
        AnotherNestedObj = new
        {
            GreatName = "Name the Great!! :D"
        }
    }
};

var schema = ObjectValidation.Schema(new
{
    FirstName = StringValidation.Schema().Min(1).Max(50),
    LastName = StringValidation.Schema().Min(1).Max(50),
    LocationStr = ObjectValidation.Schema(new
    {
        X = StringValidation.Schema().Min(1).Max(5).Int(),
        Y = StringValidation.Schema().Min(1).Max(5).Int(),
        AnotherNestedObj = ObjectValidation.Schema(new
        {
            GreatName = StringValidation.Schema().Min(5).Max(50),
        })
    })
});

var res = schema.Validate(yanni);

res.Print();