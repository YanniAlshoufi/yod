namespace Yod.Lib;

public record Result<T>(bool IsValid, List<Problem> Problems, T Input);

public record Problem(string WhileValidating, string Message);