namespace Yod.Lib.String;

public static class StringHelpers
{
    public static StringValidation BuildSimpleCondition(
        this StringValidation self,
        string constraintName,
        Func<string, bool> assertion,
        string positiveMessage,
        string negativeMessage,
        string? userMessage = null)
    {
        self.Steps.Add(cur =>
        {
            if (Helpers.IsOrInverted(!assertion(cur), self.IsInverted))
            {
                self.Problems.Add(Helpers.GetProblem(
                    constraintName,
                    self.IsInverted,
                    userMessage,
                    positiveMessage,
                    negativeMessage));
            }

            if (self.IsInvertingNextOnly)
            {
                self.IsInverted = !self.IsInverted;
                self.IsInvertingNextOnly = false;
            }

            return cur;
        });

        return self;
    }
}