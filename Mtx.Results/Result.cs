namespace Mtx.Results;

public record Result(int StatusCode, string Message = "", Exception? Exception = default)
{
	public bool IsError => StatusCode > 399;
	public bool IsSuccess => StatusCode < 400;
	public bool HasException => Exception is not null;
	public static Result Ok200() => new(Status200OK);
	public static Result NoContent204() => new(Status204NoContent);
	public static Result BadRequest400(string error = "") => new(Status400BadRequest, Message: error);
	public static Result NotFound404() => new(Status404NotFound);
	public static Result InternalError(string error = "", Exception? exception = default) => new(Status500InternalServerError, error, exception);
	public static implicit operator int(Result result) => result.StatusCode;
}