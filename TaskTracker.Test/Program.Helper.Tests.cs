using Moq;

namespace TaskTracker.Tests;

public class ProgramHelperTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(["add", "Buy groceries"], TestName = "AddTask")]
    [TestCase(["update", "1", "Buy groceries and cook dinner"], TestName = "UpdateTask")]
    [TestCase(["delete", "1"], TestName = "DeleteTask")]
    [TestCase(["mark-in-progress", "1"], TestName = "MarkInProgressTask")]
    [TestCase(["mark-done-progress", "1"], TestName = "MarkDoneTask")]
    [TestCase(["list"], TestName = "ListTask")]
    [TestCase(["list", "done"], TestName = "ListDoneTask")]
    [TestCase(["list", "in-progress"], TestName = "ListInProgressTask")]
    public void Helper_ParseArgs(params string[] args)
    {
        // Arrange
        string expectedCommand = args.Length > 0 ? args[0] : string.Empty;
        string expectedArg1 = args.Length > 1 ? args[1] : string.Empty;
        string expectedArg2 = args.Length > 2 ? args[2] : string.Empty;

        // Act
        var (command, arg1, arg2) = Program.ParseArgs(args);

        // Assert
        Assert.That(command, Is.EqualTo(expectedCommand));
        Assert.That(arg1, Is.EqualTo(expectedArg1));
        Assert.That(arg2, Is.EqualTo(expectedArg2));
    }

    [Test]
    public void Helper_ParseArgs_WithArgumentException()
    {
        var args = Array.Empty<string>();
        Assert.That(() => Program.ParseArgs(args), Throws.ArgumentException);
    }
}