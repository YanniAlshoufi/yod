using System.Numerics;

namespace Yod.Lib.Number;

// public static class NumberHelpers
// {
//     public static async Task<NumberValidation<T>> BuildSimpleCondition<T>(
//         this NumberValidation<T> self,
//         string constraintName,
//         Func<Task<bool>> assertion,
//         string positiveMessage,
//         string negativeMessage,
//         string? userMessage = null) where T : INumber<T> =>
//         BuildSimpleCondition(self, constraintName, await assertion(), positiveMessage, negativeMessage, userMessage);
//     
//     public static NumberValidation<T> BuildSimpleCondition<T>(
//         this NumberValidation<T> self,
//         string constraintName,
//         Func<bool> assertion,
//         string positiveMessage,
//         string negativeMessage,
//         string? userMessage = null) where T : INumber<T> =>
//         BuildSimpleCondition(self, constraintName, assertion(), positiveMessage, negativeMessage, userMessage);
//
//     public static NumberValidation<T> BuildSimpleCondition<T>(
//         this NumberValidation<T> self,
//         string constraintName,
//         bool assertion,
//         string positiveMessage,
//         string negativeMessage,
//         string? userMessage = null) where T : INumber<T>
//     {
//         if (Helpers.IsOrInverted(!assertion, self.IsInverted))
//         {
//             self.Problems.Add(Helpers.GetProblem(
//                 constraintName,
//                 self.IsInverted,
//                 userMessage,
//                 positiveMessage,
//                 negativeMessage));
//         }
//         
//         if (self.IsInvertingNextOnly)
//         {
//             self.IsInverted = !self.IsInverted;
//             self.IsInvertingNextOnly = false;
//         }
//
//         return self;
//     }
//     
// }