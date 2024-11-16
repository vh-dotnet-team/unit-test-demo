using Demo.Application.Enums;
using System.Collections;

namespace Demo.Application.Processes;

/// <summary>
/// Represents a healthcare process.
/// </summary>
public class HealthcareProcess
{
    /// <summary>
    /// Gets the current stage of the healthcare process.
    /// </summary>
    public HealthcareStage CurrentStage { get; private set; } = HealthcareStage.CheckIn;

    /// <summary>
    /// Moves the healthcare process to the next stage.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the process is already at the final stage.</exception>
    public void MoveToNextStage()
    {
        if (CurrentStage == HealthcareStage.Discharge)
            throw new InvalidOperationException("Already at the final stage.");

        CurrentStage++;
    }

    /// <summary>
    /// Determines whether the healthcare process is discharged.
    /// </summary>
    /// <returns>True if the current stage is Discharge; otherwise, false.</returns>
    public bool IsDischarged()
    {
        return CurrentStage == HealthcareStage.Discharge;
    }

    /// <summary>
    /// Resets the healthcare process to the initial stage.
    /// </summary>
    public void ResetProcess()
    {
        CurrentStage = HealthcareStage.CheckIn;
    }

    /// <summary>
    /// Gets the full journey of the healthcare process.
    /// </summary>
    public IEnumerable GetFullProcessJourney()
    {
        // Return all stages in order.
        return Enum.GetValues(typeof(HealthcareStage));
    }
}
