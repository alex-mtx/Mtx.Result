namespace Mtx.Results;

public record DataResult<T>
{
	private readonly Result result;

	public DataResult(int statusCode, T? Contents = default, string Message = "", Exception? Exception = null)
	{
		result = new Result(statusCode, Message, Exception);
		this.Contents = Contents;
	}


	public bool HasValue => EqualityComparer<T>.Default.Equals(Contents, default(T));
	public T? Contents { get; }

	public int StatusCode => result.StatusCode;
	public string Message => result.Message;
	public bool IsError => result.IsError;
	public bool IsSuccess => result.IsSuccess;
	public bool HasException => result.HasException;
	public Exception? Exception => result.Exception;
	public bool IsSuccessAndHasValue => IsSuccess && HasValue;
	public Result Result => result;

	public static DataResult<T> Ok200(T contents) => new(Status200OK, Contents:contents);
	public static DataResult<T> NotFound404(string error = "") => new(Status404NotFound, Message: error);
	public static DataResult<T> BadRequest400(string error = "") => new(Status400BadRequest, Message: error);
	public static DataResult<T> InternalError(string error = "", Exception? exception = default) 
		=> new(Status500InternalServerError, Message: error, Exception: exception);

	public static implicit operator T?(DataResult<T> result) => result.Contents;

}

