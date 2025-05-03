namespace Yod.Lib;

public record Result<TInput, TOutput>(bool IsValid, List<Problem> Problems, TInput Input, TOutput Output);

public record Problem(string WhileValidating, string Message);

public record struct Unit;

public enum ValidationStepKind
{
    StringToString,
    StringToINumber,
    NumberToString,
    NumberToINumber,
}