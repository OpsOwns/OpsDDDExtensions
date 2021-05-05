using System;
using System.Threading.Tasks;

namespace OpsDDDExtensions.Extensions
{
    /// <summary>
    /// Result base class
    /// </summary>
    public class Result
    {
        public Error Error { get; }
        public bool Failure => Error != null;
        protected Result(Error error = null) => Error = error;
        public static Result Fail(string message) => new(new Error(message));
        public static Result<T> Fail<T>(string message) => new(default, new Error(message));
        public static Result<T> FailEmpty<T>(string message, T value) => new(value, new Error(message));
        public static Result Ok() => new();
        public static Result<T> Ok<T>(T value) => new(value);
        public static async Task<Result<TOutput>> Then<TInput, TOutput>(Task<Result<TInput>> task, Func<TInput, Result<TOutput>> func) => (await task).Then(func);
        public static Result Combine(params Result[] results)
        {
            foreach (var result in results)
            {
                if (result.Failure)
                    return result;
            }
            return Ok();
        }
    }
    /// <summary>
    /// Result class
    /// </summary>
    /// <typeparam name="TBody">Body of object</typeparam>
    public class Result<TBody> : Result
    {
        public TBody Value { get; }
        private Result(Error error = null)
            : base(error) { }
        protected internal Result(TBody value, Error error = null)
            : base(error)
        {
            Value = value;
        }
        private async Task<Result<TResult>> Then<TResult>(Func<TBody, Task<Result<TResult>>> func) => Failure ? new Result<TResult>(Error) : await func(Value);
        public static async Task<Result<TOutput>> Then<TInput, TOutput>(Task<Result<TInput>> task, Func<TInput, Task<Result<TOutput>>> func) => await (await task).Then(func);
        public T Match<T>(Func<Error, T> leftFunc, Func<TBody, T> rightFunc) => Failure ? leftFunc(Error) : rightFunc(Value);
        public Result<TResult> Then<TResult>(Func<TBody, Result<TResult>> func) => Failure ? new Result<TResult>(Error) : func(Value);
    }
}
