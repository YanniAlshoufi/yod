using Yod.Lib.String;

namespace Yod.Lib.Object;

public class ObjectValidation : IValidation<object, Dictionary<string, object>>
{
    private readonly List<(string propertyName, StringValidation validation)> _stringSchemas = [];
    private readonly List<(string propertyName, ObjectValidation validation)> _objectSchemas = [];

    public Result<object, Dictionary<string, object>> Validate(object input)
    {
        Dictionary<string, object> output = [];
        var properties = input.GetType().GetProperties();
        
        foreach (var (propertyName, validation) in _objectSchemas)
        {
            var property = properties.FirstOrDefault(p => p.Name == propertyName)?.GetValue(input, null);

            if (property is null)
            {
                Problems.Add(new Problem("Required Constraint", $"Field '{propertyName}' is required and not provided."));
                continue;
            }

            var res = validation.Validate(property);

            output.Add(propertyName, res.Output);
            Problems.AddRange(res.Problems);
        }

        foreach (var (propertyName, validation) in _stringSchemas)
        {
            var property = (string?) properties.FirstOrDefault(p => p.Name == propertyName)?.GetValue(input, null);

            if (property is null)
            {
                Problems.Add(new Problem("Required Constraint", $"Field '{propertyName}' is required and not provided."));
                continue;
            }

            var res = validation.Validate(property);

            output.Add(propertyName, res.Output);
            Problems.AddRange(res.Problems);
        }

        return new Result<object, Dictionary<string, object>>(Problems.Count == 0, Problems, input, output);
    }

    private ObjectValidation(object obj)
    {
        var properties = obj.GetType().GetProperties();

        foreach (var property in properties)
        {
            if (property.PropertyType == typeof(StringValidation))
            {
                _stringSchemas.Add((property.Name, (StringValidation)property.GetValue(obj, null)!));
            }

            if (property.PropertyType == typeof(ObjectValidation))
            {
                _objectSchemas.Add((property.Name, (ObjectValidation)property.GetValue(obj, null)!));
            }
        }
    }

    public static ObjectValidation Schema(object obj) => new(obj);

    //
    public List<Problem> Problems { get; } = [];
    public bool IsInverted { get; set; }
    public bool IsInvertingNextOnly { get; set; }
}