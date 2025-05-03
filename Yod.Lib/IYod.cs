namespace Yod.Lib;

public interface IYod<T>
{
    Result<T> Validate();
}