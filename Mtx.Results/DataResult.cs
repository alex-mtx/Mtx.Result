namespace Mtx.Results;

public record DataResult<T>
{
	private readonly Result result;

	public DataResult(int StatusCode, T? Contents = default, string Message = "", Exception? Exception = null)
	{
		result = new Result(StatusCode, Message, Exception);
		this.Contents = Contents;
	}


	public bool HasValue => Contents is not null;
	public T? Contents { get; }

	public bool IsError => result.IsError;
	public bool IsSuccess => result.IsSuccess;
	public bool HasException => result.HasException;
	public bool IsSuccessAndHasValue => IsSuccess && HasValue;


	public static DataResult<T> Ok200(T contents) => new(Status200OK, Contents:contents);
	public static DataResult<T> NotFound404() => new(Status404NotFound);
	public static DataResult<T> BadRequest400(string error = "") => new(Status400BadRequest, Message: error);
	public static DataResult<T> InternalError(string error = "", Exception? exception = default) 
		=> new(Status500InternalServerError, Message: error, Exception: exception);

	public static implicit operator T?(DataResult<T> result) => result.Contents;

}

