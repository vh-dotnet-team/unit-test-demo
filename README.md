# Unit test demo
----------------
## HealthcareProcess NUnit Testing

This project demonstrates unit testing for a healthcare patient flow simulation using NUnit in Visual Studio. The `HealthcareProcess` class models the sequence of stages a patient goes through in a healthcare facility.

### Solution Structure

- **`src` Folder**: Contains the main project (`MainProject`) with the `HealthcareProcess` class.
- **`tests` Folder**: Contains the NUnit test project (`MainProject.UnitTests`) with tests for the `HealthcareProcess` class.

### Dependencies
- **.NET 8**: .NET Core is a cross-platform version of .NET for building websites, services, and console apps.
- **Visual Studio 2022**: Integrated development environment for .NET development.
- **Node.js**: JavaScript runtime for running npm commands.
- **NUnit**: Testing framework for writing unit tests in .NET.
- **FluentAssertions**: Provides a fluent syntax for asserting the results of unit tests.

### HealthcareProcess Class
Healthcare process class is a simple class that simulates the stages a patient goes through in a healthcare facility. The class has the following properties and methods:
- **Properties**:
  - `CurrentStage`: Represents the current stage of the patient in the healthcare process.
- **Methods**:
  - `MoveToNextStage()`: Moves the patient to the next stage in the healthcare process.
  - `GetFullProcessJourney()`: Returns a list of all stages in the healthcare process.
  - `IsDischarged()`: Checks if the patient has completed all stages and is discharged.

### Questions and Tests

1. **What is the initial stage of the healthcare process when a patient starts?**
   - **Test**: Verifies that the initial stage of the healthcare process is `Check-In`.
   - **Assertion Type**: `Assert.AreEqual`
   - **Expected Outcome**: `CurrentStage` should be `Check-In`.

2. **Does the healthcare process progress to the next stage correctly?**
   - **Test**: Confirms that calling `MoveToNextStage` advances the stage to the next step (e.g., from `Check-In` to `Triage`).
   - **Assertion Type**: `Assert.AreEqual`
   - **Expected Outcome**: Each call to `MoveToNextStage` moves the `CurrentStage` to the next expected stage in sequence.

3. **What are all the stages a patient goes through in the healthcare journey?**
   - **Test**: Verifies that `GetFullProcessJourney` returns all stages in the correct order.
   - **Assertion Type**: `CollectionAssert.AreEqual`
   - **Expected Outcome**: The journey should contain `[CheckIn, Triage, Diagnosis, Treatment, Discharge]` in that order.

4. **What happens if you try to move past the final stage?**
   - **Test**: Ensures that an exception is thrown when trying to move beyond the `Discharge` stage.
   - **Assertion Type**: `Assert.Throws`
   - **Expected Outcome**: An `InvalidOperationException` is thrown if `MoveToNextStage` is called at the `Discharge` stage.

5. **How do you check if a patient has completed all stages? (Fluent Assertions)**
   - **Test**: Confirms that `IsDischarged` returns `true` only when the patient has reached the `Discharge` stage.
   - **Assertion Type**: Fluent Assertions (`Should().BeTrue()`)
   - **Expected Outcome**: `IsDischarged` should return `true` when `CurrentStage` is `Discharge`.

### Running the Tests

1. Open the solution in Visual Studio.
2. Run `npm install` to install the required packages.
3. Build the solution.
4. Open the Test Explorer and run all tests to see the results.

