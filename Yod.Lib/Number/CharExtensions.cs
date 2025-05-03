namespace Yod.Lib.Number;

// public static class CharExtensions
// {
//     public static NumberValidation<char> Ascii(this NumberValidation<char> self, string? message = null) => self.BuildSimpleCondition(
//         "Ascii",
//         char.IsAscii(self.Input),
//         "Must be an ASCII character.",
//         "Must not be an ASCII character.",
//         message);
//     
//     public static NumberValidation<char> Letter(this NumberValidation<char> self, string? message = null) => self.BuildSimpleCondition(
//         "Letter",
//         char.IsLetter(self.Input),
//         "Must be a letter.",
//         "Must not be a letter.",
//         message);
//     
//     public static NumberValidation<char> Lowercase(this NumberValidation<char> self, string? message = null) => self.BuildSimpleCondition(
//         "Lowercase",
//         char.IsLower(self.Input),
//         "Must be a lowercase letter.",
//         "Must not be a lowercase letter.",
//         message);
//     
//     public static NumberValidation<char> Uppercase(this NumberValidation<char> self, string? message = null) => self.BuildSimpleCondition(
//         "Uppercase",
//         char.IsUpper(self.Input),
//         "Must be an uppercase letter.",
//         "Must not be an uppercase letter.",
//         message);
//     
//     public static NumberValidation<char> Digit(this NumberValidation<char> self, string? message = null) => self.BuildSimpleCondition(
//         "Digit",
//         char.IsDigit(self.Input),
//         "Must be a digit.",
//         "Must not be a digit.",
//         message);
//     
//     public static NumberValidation<char> WhiteSpace(this NumberValidation<char> self, string? message = null) => self.BuildSimpleCondition(
//         "WhiteSpace",
//         char.IsWhiteSpace(self.Input),
//         "Must be white space.",
//         "Must not be white space.",
//         message);
//     
//     public static NumberValidation<char> Control(this NumberValidation<char> self, string? message = null) => self.BuildSimpleCondition(
//         "Control",
//         char.IsControl(self.Input),
//         "Must be a control character.",
//         "Must not be a control character.",
//         message);
// }