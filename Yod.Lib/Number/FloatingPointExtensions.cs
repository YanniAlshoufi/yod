using System.Numerics;

namespace Yod.Lib.Number;

// public static class FloatingPointExtensions
// {
//     public static NumberValidation<T> NaN<T>(this NumberValidation<T> self, string? message = null) where T : IFloatingPoint<T> =>
//         self.BuildSimpleCondition(
//             "NaN",
//             T.IsNaN(self.Input),
//             $"Must be NaN.",
//             $"Must not be NaN.",
//             message);
//
//     public static NumberValidation<T> Infinity<T>(this NumberValidation<T> self, string? message = null) where T : IFloatingPoint<T> =>
//         self.BuildSimpleCondition(
//             "Infinity",
//             T.IsInfinity(self.Input),
//             $"Must be Infinity.",
//             $"Must not be Infinity.",
//             message);
//
//     public static NumberValidation<T> NegativeInfinity<T>(this NumberValidation<T> self, string? message = null) where T : IFloatingPoint<T> =>
//         self.BuildSimpleCondition(
//             "Negative Infinity",
//             T.IsNegativeInfinity(self.Input),
//             $"Must be -Infinity.",
//             $"Must not be -Infinity.",
//             message);
//     
//     public static NumberValidation<T> Finite<T>(this NumberValidation<T> self, string? message = null) where T : IFloatingPoint<T> =>
//         self.BuildSimpleCondition(
//             "Finite",
//             T.IsFinite(self.Input),
//             $"Must be Finite.",
//             $"Must not be Finite.",
//             message);
//
//     public static NumberValidation<T> ApproximatelyEquals<T>(this NumberValidation<T> self, T val, T delta, string? message = null) where T : IFloatingPoint<T> =>
//         self.BuildSimpleCondition(
//             "Approximately Equals",
//             T.Abs(val - self.Input) < delta,
//             $"Must be approximately equal to {val:.0000}.",
//             $"Must not be approximately equal to {val:.0000}.",
//             message);
// }