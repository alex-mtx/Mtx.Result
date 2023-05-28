namespace Mtx.Results;

public record Result(int StatusCode, string Message = "", Exception? Exception = default)
{
	public bool IsError => StatusCode > 399;
	public bool IsSuccess => StatusCode < 400;
	public bool HasException => Exception is not null;
	public static Result Ok200() => new(Status200OK);
	public static Result NoContent204() => new(Status204NoContent);
	public static Result BadRequest400() => new(Status400BadRequest);
	public static Result InternalError(string message = "", Exception? exception = default) => new(Status500InternalServerError, message, exception);
	public static implicit operator int(Result result) => result.StatusCode;
}

public record DataResult<T> : Result where T : class
{
	public DataResult(int StatusCode, T? Contents = default, string Message = "", Exception? Exception = null) : base(StatusCode, Message, Exception)
	{
		this.Contents = Contents;
	}
	public bool HasValue => Contents is not null;
	public T? Contents { get; }
	public static implicit operator T?(DataResult<T> result) => result.Contents;

}

