using System.Text.RegularExpressions;

namespace Yod.Lib.String;

public partial class StringValidation : IValidation<string, string>
{
    public static StringValidation Schema() => new();
    public List<Func<string, string>> Steps { get; } = [];

    public Result<string, string> Validate(string input)
    {
        var current = Steps.Aggregate(
            input,
            (cur, step) => step(cur));
        
        return new Result<string, string>(
            Problems.Count == 0,
            Problems, input, current);
    }

    public List<Problem> Problems { get; } = [];
    public bool IsInverted { get; set; } = false;
    public bool IsInvertingNextOnly { get; set; } = false;

    #region Validation Methods

    public StringValidation Min(int minLength, string? message = null) => this.BuildSimpleCondition(
        "Minimum Length",
        inp => inp.Length >= minLength,
        $"A minimum length of {minLength} is required.",
        $"Length must not reach {minLength}.",
        message);

    public StringValidation Max(int maxLength, string? message = null) => this.BuildSimpleCondition(
        "Maximum Length",
        inp => inp.Length <= maxLength,
        $"Length must not exceed {maxLength}.",
        $"Length must be above {maxLength}.",
        message);

    public StringValidation Length(int length, string? message = null) => this.BuildSimpleCondition(
        "Exact Length",
        inp => inp.Length == length,
        $"Length must be {length}.",
        $"Length must not be {length}.",
        message);

    public StringValidation Double(string? message = null) => this.BuildSimpleCondition(
        "Double String",
        inp => double.TryParse(inp, out _),
        "Must be a valid double.",
        "Must not be a valid double.",
        message);
    
    public StringValidation Int(string? message = null) => this.BuildSimpleCondition(
        "Int String",
        inp => int.TryParse(inp, out _),
        "Must be a valid int.",
        "Must not be a valid int.",
        message);

    public StringValidation Regex(string pattern, string? message = null) => this.BuildSimpleCondition(
        "Regex",
        inp => new Regex(pattern).IsMatch(inp),
        $"Must have a match for regex /{pattern}/.",
        $"Must not have a match for regex /{pattern}/.",
        message);

    public StringValidation Regex(Regex regex, string? message = null) => this.BuildSimpleCondition(
        "Regex",
        regex.IsMatch,
        $"Must have a match for regex /{regex}/.",
        $"Must not have a match for regex /{regex}/.",
        message);

    public StringValidation RegexExactMatch(string pattern, string? message = null) => this.BuildSimpleCondition(
        "Regex Exact Match",
        (inp) =>
        {
            var match = new Regex(pattern).Match(inp);
            return match.Success && match.Index == 0 && match.Groups[0].ToString() == inp;
        },
        $"Must match regex /{pattern}/ exactly.",
        $"Must not match regex /{pattern}/ exactly.",
        message);

    public StringValidation RegexExactMatch(Regex regex, string? message = null) => this.BuildSimpleCondition(
        "Regex Exact Match",
        inp =>
        {
            var match = regex.Match(inp);
            return match.Success && match.Index == 0 && match.Groups[0].ToString() == inp;
        },
        $"Must match regex /{regex}/ exactly.",
        $"Must not match regex /{regex}/ exactly.",
        message);

    public StringValidation Email(string? message = null) => this.BuildSimpleCondition(
        "Email",
        inp => EmailRegex().IsMatch(inp),
        "Must be valid email.",
        "Must not be valid email.",
        message);

    public StringValidation PhoneNumber(string? message = null) => this.BuildSimpleCondition(
        "Email",
        inp => PhoneRegex().IsMatch(inp),
        "Must be valid phone number.",
        "Must not be valid phone number.",
        message);


    public StringValidation Do(Action<string> action)
    {
        Steps.Add(inp =>
        {
            action(inp);
            return inp;
        });
        return this;
    }

    public StringValidation Transform(Func<string, string> transformer)
    {
        Steps.Add(transformer);
        return this;
    }

    // public StringValidation Trim() => this.Transform(inp => inp.Trim());

    public StringValidation Not()
    {
        Steps.Add(inp =>
        {
            IsInverted = !IsInverted;
            return inp;
        });
        return this;
    }

    public StringValidation NotNextOnly()
    {
        Steps.Add(inp =>
        {
            IsInverted = !IsInverted;
            IsInvertingNextOnly = true;
            return inp;
        });
        return this;
    }

    [GeneratedRegex(@"^(?!\.)(?!.*\.\.)([A-Z0-9_'+\-\.]*)[A-Z0-9_+-]@([A-Z0-9][A-Z0-9\-]*\.)+[A-Z]{2,}$",
        RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex EmailRegex();

    [GeneratedRegex(@"^\+?\d{1,4}?[-.\s]?\(?\d{1,3}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$")]
    private static partial Regex PhoneRegex();

    #endregion
}