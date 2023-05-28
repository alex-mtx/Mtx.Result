public class DataResultTests
{
	[Fact]
	public void DataResult_WithStatusCodeAndContents_ReturnsResultWithStatusCodeAndContents()
	{
		// Arrange
		var expectedStatusCode = 200;
		var expectedContents = "Test Contents";

		// Act
		var result = new DataResult<string>(expectedStatusCode, expectedContents);

		// Assert
		Assert.Equal(expectedStatusCode, result.StatusCode);
		Assert.Equal(expectedContents, result.Contents);
		Assert.Equal("", result.Message);
		Assert.Null(result.Exception);
	}

	[Fact]
	public void DataResult_WithStatusCodeContentsAndMessage_ReturnsResultWithStatusCodeContentsAndMessage()
	{
		// Arrange
		var expectedStatusCode = 200;
		var expectedContents = new CustomType();
		var expectedMessage = "Test Message";

		// Act
		var result = new DataResult<CustomType>(expectedStatusCode, expectedContents, expectedMessage);

		// Assert
		Assert.Equal(expectedStatusCode, result.StatusCode);
		Assert.Equal(expectedContents, result.Contents);
		Assert.Equal(expectedMessage, result.Message);
		Assert.Null(result.Exception);
	}

	[Fact]
	public void DataResult_WithStatusCodeContentsMessageAndException_ReturnsResultWithStatusCodeContentsMessageAndException()
	{
		// Arrange
		var expectedStatusCode = 200;
		var expectedContents = new AnotherType();
		var expectedMessage = "Test Message";
		var expectedException = new Exception("Test Exception");

		// Act
		var result = new DataResult<AnotherType>(expectedStatusCode, expectedContents, expectedMessage, expectedException);

		// Assert
		Assert.Equal(expectedStatusCode, result.StatusCode);
		Assert.Equal(expectedContents, result.Contents);
		Assert.Equal(expectedMessage, result.Message);
		Assert.Equal(expectedException, result.Exception);
	}

	[Fact]
	public void HasValue_WithNonNullContents_ReturnsTrue()
	{
		// Arrange
		var result = new DataResult<string>(200, "Test Contents");

		// Act
		bool hasValue = result.HasValue;

		// Assert
		Assert.True(hasValue);
	}

	[Fact]
	public void HasValue_WithNullContents_ReturnsFalse()
	{
		// Arrange
		var result = new DataResult<string>(200, null);

		// Act
		bool hasValue = result.HasValue;

		// Assert
		Assert.False(hasValue);
	}

	[Fact]
	public void ImplicitOperator_Contents_ReturnsContents()
	{
		// Arrange
		var expectedContents = "Test Contents";
		var result = new DataResult<string>(200, expectedContents);

		// Act
		string contents = result;

		// Assert
		Assert.Equal(expectedContents, contents);
	}

	private class CustomType
	{
		// Custom implementation for testing purposes
	}

	private class AnotherType
	{
		// Custom implementation for testing purposes
	}
}
