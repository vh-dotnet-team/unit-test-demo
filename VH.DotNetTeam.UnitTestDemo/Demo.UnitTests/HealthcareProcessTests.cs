using Demo.Application.Processes;

namespace Demo.UnitTests;

[TestFixture]
public class HealthcareProcessTests
{
    /// <summary>
    /// The instance of the HealthcareProcess class that will be used in the tests.
    /// </summary>
    private HealthcareProcess _healthcareProcess;
    
    /// <summary>
    /// Sets up the test environment by initializing the HealthcareProcess instance.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _healthcareProcess = new HealthcareProcess();
    }
    
    // YOUR CODE SHOULD BE IN HERE
}
