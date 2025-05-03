using System.Text.Json;

namespace Yod.Lib;

public static class ResultExtensions
{
    public static void Print<TInput, TOutput>(this Result<TInput, TOutput> validationResult)
    {
        var oldColor = Console.ForegroundColor;

        if (validationResult.IsValid)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(JsonSerializer.Serialize(validationResult.Output!, Helpers.PrettyJsonSerializerOptions));
            Console.ForegroundColor = oldColor;
            return;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine($"Encountered errors validating '{validationResult.Input}'...");
        Console.ForegroundColor = oldColor;
        
        foreach (var problem in validationResult.Problems)
        {
            Console.WriteLine($"- '{problem.WhileValidating}' failed: {problem.Message}");
        }
    }
}