using System.Numerics;

namespace Yod.Lib.Number;

// public class NumberValidation<TInput, TOutput> : IValidation<TInput, TOutput> 
//     where TInput : INumber<TInput>
//     where TOutput : INumber<TOutput>
// {
//     private NumberValidation(TInput input)
//     {
//         Input = input;
//     }
//     
//     /// <summary>
//     /// Number validators all have Min, Max, Equals, Not, and NotNextOnly. Then, depending on the type of number,
//     /// you get specialized further validation options. E.g., floating point numbers have ApproximatelyEquals.
//     /// Note that char validation is shared between `Number` and `Char`
//     /// </summary>
//     /// <param name="val">Input to validate on</param>
//     /// <returns>A StringValidation object, which is an intermediate validation object.</returns>
//     public static NumberValidation<TInput> On(TInput val) => new(val);
//
//     // public Result<TInput, TOutput> Validate() => new(Problems.Count == 0, Problems, Input);
//
//     public TInput Input { get; }
//     public List<Problem> Problems { get; } = [];
//     public bool IsInverted { get; set; } = false;
//     public bool IsInvertingNextOnly { get; set; } = false;
//
//     #region Validation Methods
//
//     public NumberValidation<TInput> Min(TInput min, string? message = null) => this.BuildSimpleCondition(
//         "Minimum",
//         Input >= min,
//         $"A minimum of {min} is required.",
//         $"At least {min} is required.",
//         message);
//
//     public NumberValidation<TInput> Max(TInput max, string? message = null) => this.BuildSimpleCondition(
//         "Maximum",
//         Input <= max,
//         $"Cannot exceed {max}.",
//         $"Must be at least {max}.",
//         message);
//
//     public NumberValidation<TInput> Equals(TInput val, string? message = null) => this.BuildSimpleCondition(
//         "Equals",
//         Input == val,
//         $"Must be {val}",
//         $"Must not be {val}.",
//         message);
//
//     public NumberValidation<TInput> Not()
//     {
//         IsInverted = !IsInverted;
//         return this;
//     }
//
//     public NumberValidation<TInput> NotNextOnly()
//     {
//         IsInverted = !IsInverted;
//         IsInvertingNextOnly = true;
//         return this;
//     }
//
//     #endregion
// }