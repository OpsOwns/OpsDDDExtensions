using System;

namespace OpsDDDExtensions.Extensions
{
    /// <summary>
    /// Result class
    /// </summary>
    /// <typeparam name="TBody">Body of object</typeparam>
    public class Result<TBody>
    {
        public Error Error { get; }
        public TBody Body { get; }
        public bool IsError => Error != null;
        private Result(Error error) => Error = error;
        private Result(TBody body) => Body = body;
        public Result<TResult> Then<TResult>(Func<TBody, Result<TResult>> func) => IsError ? Error : func(Body);
        public static Result<TBody> Success(TBody body) => new(body);
        public static Result<TBody> Fail(string message) => new(new Error(message));
        public T Match<T>(Func<Error, T> leftFunc, Func<TBody, T> rightFunc) => IsError ? leftFunc(Error) : rightFunc(Body);

        public static implicit operator Result<TBody>(Error error) => new(error);

        public static implicit operator Result<TBody>(TBody body) => new(body);

        public static implicit operator TBody(Result<TBody> result) => result.Body;
    }
}
