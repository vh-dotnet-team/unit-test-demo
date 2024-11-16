using Demo.Application.Enums;
using Demo.Application.Interfaces;
using Demo.Application.Processes;
using System.Collections;

namespace Demo.Application.Services;

/// <inheritdoc/>
public class HealthcareProcessService : IHealthcareProcessService
{
    /// <inheritdoc/>
    private readonly HealthcareProcess _process = new();

    /// <inheritdoc/>
    public HealthcareStage GetCurrentStage()
    {
        return _process.CurrentStage;
    }

    /// <inheritdoc/>
    public void MoveToNextStage()
    {
        _process.MoveToNextStage();
    }

    /// <inheritdoc/>
    public bool IsDischarged()
    {
        return _process.IsDischarged();
    }

    /// <inheritdoc/>
    public void ResetProcess()
    {
        _process.ResetProcess();
    }

    /// <inheritdoc/>
    public IEnumerable GetFullProcessJourney()
    {
        return _process.GetFullProcessJourney();
    }
}
