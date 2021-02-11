namespace Services.Dto
{
    public abstract class BaseDto : BaseDto<int>
    {
    }

    public abstract class BaseDto<T>
    {
        public T Id { get; set; }
    }
}