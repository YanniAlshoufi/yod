namespace Yod.Lib.String;

public class Yod(string input) : IYod<string>
{
    private readonly string _stringInput = input;
    
    public static Yod String(string inp) => new(inp);
    public Result<string> Validate() => new(_problems.Count == 0, _problems, _input);

    private readonly string _input = input;
    private readonly List<Problem> _problems = [];
    private bool _isInverted = false;
    
    #region Validation Methods

    public Yod Min(int minLength, string? message = null)
    {
        if (_input.Length < minLength)
        {
            _problems.Add(new Problem(
                "Minimum Length Constraint",
                message ?? $"A minimum length of {minLength} is required."));
        }

        return this;
    }

    public Yod Max(int maxLength, string? message = null)
    {
        if (_input.Length > maxLength)
        {
            _problems.Add(new Problem(
                "Maximum Length Constraint",
                message ?? $"Length must not exceed {maxLength}."));
        }

        return this;
    }

    public Yod Length(int length, string? message = null)
    {
        if (_input.Length != length)
        {
            _problems.Add(new Problem(
                "Exact Length Constraint",
                message ?? $"Length must be {length}."));
        }

        return this;
    }

    public Yod Double(string? message = null)
    {
        if (!double.TryParse(_input, out _))
        {
            _problems.Add(new Problem(
                "Double String Constraint",
                message ?? $"Must be a valid double."));
        }

        return this;
    }

    public Yod Int(string? message = null)
    {
        if (!int.TryParse(_input, out _))
        {
            _problems.Add(new Problem(
                "Int String Constraint",
                message ?? $"Must be a valid int."));
        }

        return this;
    }

    public IYod<string> Not()
    {
        _isInverted = !_isInverted;
        return this;
    }
    
    #endregion
}
