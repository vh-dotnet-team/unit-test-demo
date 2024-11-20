using Demo.Application.Enums;
using Demo.Application.Processes;
using FluentAssertions;

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
	#region Question 1: Initial Stage Check
	/// <summary>
	/// Tests that the initial stage of the healthcare process is Check-In.
	/// </summary>
	[Test]
	public void HealthcareProcess_InitialStage_ShouldBeCheckIn()
	{
		// Verify that the initial stage is Check-In.
		Assert.AreEqual(HealthcareStage.CheckIn, _healthcareProcess.CurrentStage,
			"Initial stage should be Check-In.");
	}
	#endregion

	#region Question 2: Moving to the Next Stage
	/// <summary>
	/// Tests that the healthcare process progresses to the next stage correctly.
	/// </summary>
	[Test]
	public void MoveToNextStage_ShouldProgressToNextStage()
	{
		// Check-In -> Triage
		_healthcareProcess.MoveToNextStage();
		Assert.AreEqual(HealthcareStage.Triage, _healthcareProcess.CurrentStage);

		// Triage -> Diagnosis
		_healthcareProcess.MoveToNextStage();
		Assert.AreEqual(HealthcareStage.Diagnosis, _healthcareProcess.CurrentStage);

		// Diagnosis -> Treatment
		_healthcareProcess.MoveToNextStage();
		Assert.AreEqual(HealthcareStage.Treatment, _healthcareProcess.CurrentStage);

		// Treatment -> Discharge
		_healthcareProcess.MoveToNextStage();
		Assert.AreEqual(HealthcareStage.Discharge, _healthcareProcess.CurrentStage);
	}
	#endregion

	#region Question 3: Full Journey Check
	/// <summary>
	/// Tests that the full journey of the healthcare process includes all stages in the correct order.
	/// </summary>
	[Test]
	public void GetFullProcessJourney_ShouldReturnAllStagesInOrder()
	{
		// Verify that the full journey includes all stages in the correct order.
		var journey = _healthcareProcess.GetFullProcessJourney();
		var expectedStages = new List<HealthcareStage>
		{
			HealthcareStage.CheckIn,
			HealthcareStage.Triage,
			HealthcareStage.Diagnosis,
			HealthcareStage.Treatment,
			HealthcareStage.Discharge
		};
		CollectionAssert.AreEqual(expectedStages, journey,
			"The journey should contain all healthcare stages in the correct order.");
	}
	#endregion

	#region Question 4: Exception Beyond Discharge
	/// <summary>
	/// Tests that attempting to move to the next stage after Discharge throws an InvalidOperationException.
	/// </summary>
	[Test]
	public void MoveToNextStage_AfterDischarge_ShouldThrowInvalidOperationException()
	{
		// Progress to Discharge
		_healthcareProcess.MoveToNextStage(); // Check-In -> Triage
		_healthcareProcess.MoveToNextStage(); // Triage -> Diagnosis
		_healthcareProcess.MoveToNextStage(); // Diagnosis -> Treatment
		_healthcareProcess.MoveToNextStage(); // Treatment -> Discharge

		// Attempting to move past Discharge should throw an exception.
		Assert.Throws<InvalidOperationException>(() => _healthcareProcess.MoveToNextStage(),
			"Moving beyond Discharge should throw an InvalidOperationException.");
	}
	#endregion

	#region Question 5: Final Stage Check (Fluent Assertions)
	/// <summary>
	/// Tests that IsDischarged returns true when the current stage is Discharge.
	/// </summary>
	[Test]
	public void IsDischarged_WhenAtDischarge_ShouldReturnTrue()
	{
		// Move to the final stage, Discharge.
		_healthcareProcess.MoveToNextStage(); // Check-In -> Triage
		_healthcareProcess.MoveToNextStage(); // Triage -> Diagnosis
		_healthcareProcess.MoveToNextStage(); // Diagnosis -> Treatment
		_healthcareProcess.MoveToNextStage(); // Treatment -> Discharge

		// Confirm using Fluent Assertions
		_healthcareProcess.IsDischarged().Should().BeTrue("IsDischarged should return true when the current stage is Discharge.");
	}
	#endregion
}
