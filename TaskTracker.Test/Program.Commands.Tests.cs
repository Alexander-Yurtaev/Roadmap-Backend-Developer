using Moq;

namespace TaskTracker.Tests;

public class ProgramCommandsTests
{
    private Mock<List<TaskEntity>> _mockTaskEntities;

    [SetUp]
    public void Setup()
    {
        _mockTaskEntities = new Mock<List<TaskEntity>>();
    }

    [Test]
    public void Commands_AddTask_WithEmptyRepository()
    {
        // Arrange
        var moqRepository = new Mock<ITaskTrackerRepository>();
        moqRepository.Setup(r => r.LoadAllTasks(It.IsAny<TaskStatus?>())).Returns(_mockTaskEntities.Object);
        moqRepository.Setup(r => r.SaveJsonData(_mockTaskEntities.Object));

        // Act
        int id = Program.AddTask("New Test Task", moqRepository.Object);

        // Assert
        Assert.That(id, Is.EqualTo(1));
    }

    [Test]
    public void Commands_AddTask_WithNotEmptyRepository()
    {
        // Arrange
        var moqRepository = new Mock<ITaskTrackerRepository>();
        moqRepository.Setup(r => r.LoadAllTasks(It.IsAny<TaskStatus?>())).Returns(_mockTaskEntities.Object);
        moqRepository.Setup(r => r.SaveJsonData(_mockTaskEntities.Object));

        // Act
        Program.AddTask("New Test Task 1", moqRepository.Object);
        int id = Program.AddTask("New Test Task 2", moqRepository.Object);

        // Assert
        Assert.That(id, Is.EqualTo(2));
    }

    [Test]
    public void Commands_UpdateTask()
    {
        // Arrange
        var moqRepository = new Mock<ITaskTrackerRepository>();
        moqRepository.Setup(r => r.LoadAllTasks(It.IsAny<TaskStatus?>())).Returns(_mockTaskEntities.Object);
        moqRepository.Setup(r => r.SaveJsonData(_mockTaskEntities.Object));
        int id = Program.AddTask("Test Task", moqRepository.Object);

        // Act
        Program.UpdateTask(id, "Update Task", moqRepository.Object);
        List<TaskEntity> tasks = moqRepository.Object.LoadAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);

        // Assert
        Assert.That(task, Is.Not.Null);
        Assert.That(task.Id, Is.EqualTo(id));
    }

    [Test]
    public void Commands_UpdateTask_WithWrongId()
    {
        // Arrange
        var moqRepository = new Mock<ITaskTrackerRepository>();
        moqRepository.Setup(r => r.LoadAllTasks(It.IsAny<TaskStatus?>())).Returns(_mockTaskEntities.Object);
        moqRepository.Setup(r => r.SaveJsonData(_mockTaskEntities.Object));
        int wrongId = 1000;

        // Act
        Assert.DoesNotThrow(() => Program.UpdateTask(wrongId, "Update Task", moqRepository.Object));
        List<TaskEntity> tasks = moqRepository.Object.LoadAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == wrongId);

        // Assert
        Assert.That(task, Is.Null);
    }

    [Test]
    public void Commands_DeleteTask()
    {
        // Arrange
        var moqRepository = new Mock<ITaskTrackerRepository>();
        moqRepository.Setup(r => r.LoadAllTasks(It.IsAny<TaskStatus?>())).Returns(_mockTaskEntities.Object);
        moqRepository.Setup(r => r.SaveJsonData(_mockTaskEntities.Object));
        int id = Program.AddTask("Delete Test Task", moqRepository.Object);

        // Act
        Program.DeleteTask(id, moqRepository.Object);
        List<TaskEntity> tasks = moqRepository.Object.LoadAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);

        // Assert
        Assert.That(task, Is.Null);
    }

    [Test]
    public void Commands_DeleteTask_WithWrongId()
    {
        // Arrange
        var moqRepository = new Mock<ITaskTrackerRepository>();
        moqRepository.Setup(r => r.LoadAllTasks(It.IsAny<TaskStatus?>())).Returns(_mockTaskEntities.Object);
        moqRepository.Setup(r => r.SaveJsonData(_mockTaskEntities.Object));
        const int wrongId = 1000;

        // Act
        Assert.DoesNotThrow(() => Program.DeleteTask(wrongId, moqRepository.Object));
        List<TaskEntity> tasks = moqRepository.Object.LoadAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == wrongId);

        // Assert
        Assert.That(task, Is.Null);
    }

    [Test]
    public void Commands_MarkInProgressTask()
    {
        // Arrange
        var moqRepository = new Mock<ITaskTrackerRepository>();
        moqRepository.Setup(r => r.LoadAllTasks(It.IsAny<TaskStatus?>())).Returns(_mockTaskEntities.Object);
        moqRepository.Setup(r => r.SaveJsonData(_mockTaskEntities.Object));
        int id = Program.AddTask("Test Task", moqRepository.Object);

        // Act
        Program.MarkInProgressTask(id, moqRepository.Object);
        List<TaskEntity> tasks = moqRepository.Object.LoadAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);

        // Assert
        Assert.That(task, Is.Not.Null);
        Assert.That(task.Status, Is.EqualTo(TaskStatus.InProcess));
    }

    [Test]
    public void Commands_MarkInProgressTask_WithWrongId()
    {
        // Arrange
        var moqRepository = new Mock<ITaskTrackerRepository>();
        moqRepository.Setup(r => r.LoadAllTasks(It.IsAny<TaskStatus?>())).Returns(_mockTaskEntities.Object);
        moqRepository.Setup(r => r.SaveJsonData(_mockTaskEntities.Object));
        const int wrongId = 1000;

        // Act
        Assert.DoesNotThrow(() => Program.MarkInProgressTask(wrongId, moqRepository.Object));
        List<TaskEntity> tasks = moqRepository.Object.LoadAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == wrongId);

        // Assert
        Assert.That(task, Is.Null);
    }

    [Test]
    public void Commands_MarkDoneTask()
    {
        // Arrange
        var moqRepository = new Mock<ITaskTrackerRepository>();
        moqRepository.Setup(r => r.LoadAllTasks(It.IsAny<TaskStatus?>())).Returns(_mockTaskEntities.Object);
        moqRepository.Setup(r => r.SaveJsonData(_mockTaskEntities.Object));
        int id = Program.AddTask("Test Task", moqRepository.Object);

        // Act
        Program.MarkDoneTask(id, moqRepository.Object);
        List<TaskEntity> tasks = moqRepository.Object.LoadAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);

        // Assert
        Assert.That(task, Is.Not.Null);
        Assert.That(task.Status, Is.EqualTo(TaskStatus.Done));
    }

    [Test]
    public void Commands_MarkDoneTask_WithWrongId()
    {
        // Arrange
        var moqRepository = new Mock<ITaskTrackerRepository>();
        moqRepository.Setup(r => r.LoadAllTasks(It.IsAny<TaskStatus?>())).Returns(_mockTaskEntities.Object);
        moqRepository.Setup(r => r.SaveJsonData(_mockTaskEntities.Object));
        const int wrongId = 1000;

        // Act
        Assert.DoesNotThrow(() => Program.MarkDoneTask(wrongId, moqRepository.Object));
        List<TaskEntity> tasks = moqRepository.Object.LoadAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == wrongId);

        // Assert
        Assert.That(task, Is.Null);
    }

    [Test]
    [TestCase(null, TestName = "ListTasks - Null")]
    [TestCase(TaskStatus.Done, TestName = "ListTasks - Done")]
    [TestCase(TaskStatus.InProcess, TestName = "ListTasks - In process")]
    public void Commands_ListTasks(TaskStatus? status)
    {
        // Arrange
        var moqRepository = new Mock<ITaskTrackerRepository>();
        moqRepository.Setup(r => r.LoadAllTasks(It.IsAny<TaskStatus?>())).Returns(_mockTaskEntities.Object);

        // Act
        // Assert
        Assert.DoesNotThrow(() => moqRepository.Object.LoadAllTasks(status));
    }
}