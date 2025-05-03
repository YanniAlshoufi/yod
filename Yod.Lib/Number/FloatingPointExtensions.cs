using System.Numerics;

namespace Yod.Lib.Number;

public static class FloatingPointExtensions
{
    public static Yod<T> NaN<T>(this Yod<T> self, string? message = null) where T : IFloatingPoint<T>
    {
        if (Helpers.IsOrInverted(!T.IsNaN(self.Input), self.IsInverted))
        {
            self.Problems.Add(Helpers.GetProblem(
                "NaN",
                self.IsInverted,
                message,
                "Must be NaN.",
                "Must not be NaN."));
        }

        return self;
    }

    public static Yod<T> Infinity<T>(this Yod<T> self, string? message = null) where T : IFloatingPoint<T>
    {
        if (Helpers.IsOrInverted(!T.IsInfinity(self.Input), self.IsInverted))
        {
            self.Problems.Add(Helpers.GetProblem(
                "Infinity",
                self.IsInverted,
                message,
                "Must be Infinity.",
                "Must not be Infinity."));
        }

        return self;
    }

    public static Yod<T> NegativeInfinity<T>(this Yod<T> self, string? message = null) where T : IFloatingPoint<T>
    {
        if (Helpers.IsOrInverted(!T.IsNegativeInfinity(self.Input), self.IsInverted))
        {
            self.Problems.Add(Helpers.GetProblem(
                "Negative Infinity",
                self.IsInverted,
                message,
                "Must be -Infinity.",
                "Must not be -Infinity."));
        }

        return self;
    }

    public static Yod<T> Finite<T>(this Yod<T> self, string? message = null) where T : IFloatingPoint<T>
    {
        if (Helpers.IsOrInverted(T.IsNegativeInfinity(self.Input) || T.IsInfinity(self.Input), self.IsInverted))
        {
            self.Problems.Add(Helpers.GetProblem(
                "Finite",
                self.IsInverted,
                message,
                "Must be Finite.",
                "Must not be Finite."));
        }

        return self;
    }

    public static Yod<T> ApproximatelyEquals<T>(this Yod<T> self, T val, T delta, string? message = null)
        where T : IFloatingPoint<T>
    {
        if (Helpers.IsOrInverted(T.Abs(val - self.Input) >= delta, self.IsInverted))
        {
            self.Problems.Add(Helpers.GetProblem(
                "Approximately Equals",
                self.IsInverted,
                message,
                $"Must be approximately equal to {val:.0000}.",
                $"Must not be approximately equal to {val:.0000}."));
        }

        return self;
    }
}