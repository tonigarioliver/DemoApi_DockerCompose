using DemoApp.Core.IConfiguration;
using DemoApp.Data;
using DemoApp.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly ILogger<DriversController> _logger;
    private readonly IUnitOfWork _UnitOfWork;
    public DriversController(
        ILogger<DriversController> logger,
        IUnitOfWork UnitOfWork)
    {
        _logger = logger;
        _UnitOfWork = UnitOfWork;
    }

    [HttpGet(Name = "GetAllDriver")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var driver = new Driver()
        {
            DriverNumber=44,
            Name = "Sir Lewis Hamilton"
        };

        await _UnitOfWork.Drivers.CreateAsync(driver);
        await _UnitOfWork.CompleteAsyn();
        var allDrivers=  await _UnitOfWork.Drivers.GetAllAsync();
        return Ok(allDrivers);
    }

}
