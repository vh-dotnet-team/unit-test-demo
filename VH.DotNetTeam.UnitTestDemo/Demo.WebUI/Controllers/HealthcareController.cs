using Demo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebUI.Controllers;


/// <summary>
/// Controller for managing the healthcare process.
/// </summary>
public class HealthcareController : Controller
{
    /// <summary>
    /// The healthcare process service.
    /// </summary>
    private readonly IHealthcareProcessService _processService;

    /// <summary>
    /// Initializes a new instance of the <see cref="HealthcareController"/> class.
    /// </summary>
    /// <param name="processService">The healthcare process service.</param>
    public HealthcareController(IHealthcareProcessService processService)
    {
        _processService = processService;
    }

    /// <summary>
    /// Displays the current stage of the healthcare process.
    /// </summary>
    /// <returns>The view with the current stage.</returns>
    public IActionResult Index()
    {
        var currentStage = _processService.GetCurrentStage();
        return View(currentStage);
    }

    /// <summary>
    /// Moves the healthcare process to the next stage.
    /// </summary>
    /// <returns>Redirects to the Index action.</returns>
    [HttpPost]
    public IActionResult MoveNext()
    {
        try
        {
            _processService.MoveToNextStage();
            return RedirectToAction("Index");
        }
        catch (InvalidOperationException ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    /// <summary>
    /// Resets the healthcare process to the initial stage.
    /// </summary>
    /// <returns>Redirects to the Index action.</returns>
    [HttpPost]
    public IActionResult Reset()
    {
        _processService.ResetProcess();
        TempData["Message"] = "Process reset to Check-In.";
        return RedirectToAction("Index");
    }
}
