namespace Mtx.ResultsTests
{
	public class ResultTests
	{
		[Fact]
		public void ImplicitOperator_StatusCode_ReturnsStatusCode()
		{
			// Arrange
			var result = new Result(200);

			// Act
			int statusCode = result;

			// Assert
			Assert.Equal(200, statusCode);
		}

		[Fact]
		public void Ok200_ReturnsResultWithStatusCode200()
		{
			// Arrange
			var expectedStatusCode = 200;

			// Act
			var result = Result.Ok200();

			// Assert
			Assert.Equal(expectedStatusCode, result.StatusCode);
		}

		[Fact]
		public void NoContent204_ReturnsResultWithStatusCode204()
		{
			// Arrange
			var expectedStatusCode = 204;

			// Act
			var result = Result.NoContent204();

			// Assert
			Assert.Equal(expectedStatusCode, result.StatusCode);
		}

		[Fact]
		public void BadRequest400_ReturnsResultWithStatusCode400()
		{
			// Arrange
			var expectedStatusCode = 400;

			// Act
			var result = Result.BadRequest400();

			// Assert
			Assert.Equal(expectedStatusCode, result.StatusCode);
		}

		[Fact]
		public void InternalError_WithMessageAndException_ReturnsResultWithStatusCode500()
		{
			// Arrange
			var expectedStatusCode = 500;
			var expectedMessage = "Test message";
			var expectedException = new Exception("Test exception");

			// Act
			var result = Result.InternalError(expectedMessage, expectedException);

			// Assert
			Assert.Equal(expectedStatusCode, result.StatusCode);
			Assert.Equal(expectedMessage, result.Message);
			Assert.Equal(expectedException, result.Exception);
		}

		[Fact]
		public void InternalError_WithoutMessageAndException_ReturnsResultWithStatusCode500()
		{
			// Arrange
			var expectedStatusCode = 500;

			// Act
			var result = Result.InternalError();

			// Assert
			Assert.Equal(expectedStatusCode, result.StatusCode);
			Assert.Equal("", result.Message);
			Assert.Null(result.Exception);
		}
	}
}
