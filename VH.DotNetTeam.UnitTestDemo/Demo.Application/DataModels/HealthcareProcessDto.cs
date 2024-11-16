using Demo.Application.Enums;

namespace Demo.Application.DataModels;


/// <summary>
/// Data transfer object representing a healthcare process.
/// </summary>
public class HealthcareProcessDto
{
    /// <summary>
    /// Gets or sets the current stage of the healthcare process.
    /// </summary>
    public HealthcareStage CurrentStage { get; set; }
}
