namespace Yod.Lib;

public static class Helpers
{
    public static Problem GetProblem(
        string constraintName,
        bool isInverted, 
        string? userMessage,
        string positiveMessage,
        string negativeMessage)
    {
        
        return new Problem(
            $"{(isInverted ? "Not " : string.Empty)}{constraintName} Constraint",
            userMessage ?? (
                isInverted
                ? negativeMessage
                : positiveMessage
            ));
    }

    public static bool IsOrInverted(bool condition, bool isInverted)
    {
        return condition ^ isInverted;
    }
}