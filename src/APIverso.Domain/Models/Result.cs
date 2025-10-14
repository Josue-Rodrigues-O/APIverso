using APIverso.Domain.Enums;

namespace APIverso.Domain.Models
{
    public class Result<TType>
    {
        public TType? Success { get; private set; }
        public Failure? Failure { get; private set; }
        private Result(TType success) { Success = success; }
        private Result(Failure failure) { Failure = failure; }
        public bool IsSuccess => Success != null && Failure == null;
        public bool IsFailure => Failure != null && Success == null;
        public static Result<TType> AsSuccess(TType data) => new(data);
        public static Result<TType> AsFailure(Failure failure) => new(failure);
        public Result<TNewType> Map<TNewType>(Func<TType, TNewType> transform)
        {
            return IsSuccess
                ? Result<TNewType>.AsSuccess(transform(Success!))
                : Result<TNewType>.AsFailure(Failure!);
        }
        
        public Result<TNewType> Bind<TNewType>(Func<TType, Result<TNewType>> nextOperation)
        {
            return IsSuccess
                ? nextOperation(Success!)
                : Result<TNewType>.AsFailure(Failure!);
        }
    }

    public record Failure(string Title, FailureTypeEnum Type);
}