namespace Chinook.Domain.Converters
{
    public interface IConvertModel<TSource, TTarget>
    {
        TTarget Convert { get; }
    }
}