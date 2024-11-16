using Demo.Application.Enums;
using System.Collections;

namespace Demo.Application.Interfaces;


/// <summary>
/// Interface for managing the healthcare process.
/// </summary>
public interface IHealthcareProcessService
{
    /// <summary>
    /// Gets the current stage of the healthcare process.
    /// </summary>
    /// <returns>The current <see cref="HealthcareStage"/>.</returns>
    HealthcareStage GetCurrentStage();

    /// <summary>
    /// Moves the healthcare process to the next stage.
    /// </summary>
    void MoveToNextStage();

    /// <summary>
    /// Determines whether the patient is discharged.
    /// </summary>
    /// <returns><c>true</c> if the patient is discharged; otherwise, <c>false</c>.</returns>
    bool IsDischarged();

    /// <summary>
    /// Resets the healthcare process to the initial stage.
    /// </summary>
    void ResetProcess();

    /// <summary>
    /// Gets the full journey of the healthcare process.
    /// </summary>
    /// <returns></returns>
    IEnumerable GetFullProcessJourney();
}
