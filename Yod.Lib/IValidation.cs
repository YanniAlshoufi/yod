namespace Yod.Lib;

public interface IValidation<TInput, TOutput>
{
    List<Problem> Problems { get; }
    bool IsInverted { get; set; }
    bool IsInvertingNextOnly { get; set; }
    Result<TInput, TOutput> Validate(TInput input);
}