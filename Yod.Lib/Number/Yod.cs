using System.Numerics;

namespace Yod.Lib.Number;

public class Yod<T>(T input) : IYod<T>
    where T : INumber<T>
{
    /// <summary>
    /// Number validators all have Min, Max, and Equals. Then, depending on the type of number,
    /// you get specialized further validation options. E.g., floating point numbers have ApproximatelyEquals.
    /// Note that char validation is shared between `Number` and `Char`
    /// </summary>
    /// <param name="val">Input to validate on</param>
    /// <returns>A Yod object, which is an intermediate validation object.</returns>
    public static Yod<T> Number(T val) => new(val);
    public Result<T> Validate() => new(Problems.Count == 0, Problems, Input);

    public T Input => input;
    public List<Problem> Problems { get; } = [];
    public bool IsInverted { get; private set; } = false;

    #region Validation Methods

    public Yod<T> Min(T min, string? message = null)
    {
        if (Helpers.IsOrInverted(Input < min, IsInverted))
        {
            Problems.Add(Helpers.GetProblem(
                "Minimum",
                IsInverted,
                message,
                $"A minimum of {min} is required.",
                $"At least {min} is required."));
        }

        return this;
    }

    public Yod<T> Max(T max, string? message = null)
    {
        if (Helpers.IsOrInverted(Input > max, IsInverted))
        {
            Problems.Add(Helpers.GetProblem(
                "Maximum",
                IsInverted,
                message,
                $"Cannot exceed {max}.",
                $"Must be at least {max}."));
        }

        return this;
    }

    public Yod<T> Equals(T val, string? message = null)
    {
        if (Helpers.IsOrInverted(Input != val, IsInverted))
        {
            Problems.Add(Helpers.GetProblem(
                "Equals",
                IsInverted,
                message,
                $"Must be {val}.",
                $"Must not be {val}."));
        }

        return this;
    }

    public Yod<T> NotFollowing()
    {
        IsInverted = !IsInverted;
        return this;
    }

    #endregion
}